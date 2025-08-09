using Demo.Domain.RentalContracting.Entities;
using Demo.Domain.RentalContracting.Enums;
using Demo.Domain.RentalContracting.Events;
using Demo.Domain.RentalContracting.Exceptions;
using Demo.Domain.RentalContracting.ValueObjects;
using Demo.SharedKernel.Core.Models;

namespace Demo.Domain.RentalContracting;

/// <summary>
/// The Rental class is the Aggregate Root for the RentalContracting bounded context.
/// It is responsible for maintaining the consistency boundaries of the Rental aggregate,
/// ensuring all invariants related to a rental are upheld, and that it evolves correctly
/// between state transitions (always in a valid state.)
/// </summary>
public class Rental : AggregateRoot<RentalId>
{
    /// <summary>
    /// The Rental AggregateRoot is responsible in guarding
    /// the <see cref="RentalCar"/> and ensuring that it is in a consistent state.
    /// </summary>
    public RentalCar Car { get; private set; }

    /// <summary>
    /// The Rental AggregateRoot is responsible in guarding
    /// the <see cref="RentalCar"/> and ensuring that it is in a consistent state.
    /// </summary>
    public Driver PrimaryDriver { get; private set; }

    /// <summary>
    /// A second driver can be added to a rental, given that
    /// there is an addon purchased that enables this.
    /// </summary>
    public Driver? SecondaryDriver { get; private set; }

    /// <summary>
    /// Represents the Check-in and Check-out dates for the rental.
    /// Encapsulated as a ValueObject as there is rich domain logic involved.
    /// </summary>
    public RentalPeriod Period { get; private set; }

    /// <summary>
    /// Transitions include:
    ///     Open -> In Progress -> Stopped -> Closed
    ///     Open -> Cancelled
    /// </summary>
    public RentalStatus Status { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int MaximumDriverCount { get; private set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="Rental"/> class.
    /// It enforces key business rules during creation:
    /// - Validates the primary driver's age and license.
    /// - Initializes the rental with default policies and rates from the car.
    /// - Sets the initial status to 'Open'.
    /// 
    /// Ideally we would use a factory method to construct a complex aggregate,
    /// as this would make it simpler to work with as the number of invariants grow, or
    /// even if the construction of the Aggregate gets complex.
    /// </summary>
    /// <param name="id">The unique identifier for the rental.</param>
    /// <param name="car">The car being rented.</param>
    /// <param name="primaryDriver">The main driver for the rental; the customer.</param>
    /// <param name="period">The rental period.</param>
    public Rental(RentalId id, RentalCar car, Driver primaryDriver, RentalPeriod period, int maximumDriverCount = 1)
        : base(id)
    {
        Car = car;
        PrimaryDriver = primaryDriver
            .CheckAge()
            .CheckLicense();
        Period = period;
        Status = RentalStatus.Open;
        MaximumDriverCount = maximumDriverCount;
    }


    /// <summary>
    /// Adds a secondary driver to the rental.
    /// This method enforces the business rule that a specific addon is required to allow a second driver.
    /// </summary>
    /// <param name="secondDriver">The secondary driver to add.</param>
    /// <exception cref="MissingAddonException">Thrown if the addon that enables an additional driver has not been selected.</exception>

    public void AddSecondaryDriver(Driver secondDriver)
    {
        if (MaximumDriverCount < 2)
            throw new Exception("TODO: Exception");

        SecondaryDriver = secondDriver
            .CheckAge()
            .CheckLicense();
    }

    /// <summary>
    /// Transitions the rental status from 'Open' to 'InProgress'.
    /// This signifies that the car has been handed over to the driver.
    /// </summary>
    /// <exception cref="InvalidRentalStateException">Thrown if the rental is not in the 'Open' state.</exception>
    public void CheckIn()
    {
        if (Status != RentalStatus.Open)
        {
            throw new InvalidRentalStateException("Cannot check-in a rental that has already been checked-in");
        }

        Status = RentalStatus.InProgress;
        AddDomainEvent(new RentalCheckedInEvent(Id, Car.Id, PrimaryDriver.Id, Period));
    }


    /// <summary>
    /// Extends the rental period to a new checkout date.
    /// This method enforces business rules:
    /// - The rental must be 'Open' or 'InProgress' to be extended.
    /// - The new date must be valid (after the current checkout date and after the check-in date).
    /// </summary>
    /// <param name="newDate">The new checkout date.</param>
    /// <exception cref="InvalidRentalStateException">Thrown if the rental is not 'Open' or 'InProgress'.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the new date is invalid according to <see cref="RentalPeriod.Extend"/>.</exception>

    public void ExtendUntil(DateTimeOffset newDate)
    {
        if (Status != RentalStatus.Open && Status != RentalStatus.InProgress)
        {
            throw new InvalidRentalStateException("Cannot extend a rental that isn't active.");
        }

        Period = RentalPeriod.Extend(Period, newDate);
        AddDomainEvent(new RentalExtendedEvent(Id, Period));
    }

    /// <summary>
    /// Transitions the rental status from 'InProgress' to 'Stopped'.
    /// This signifies that the car has been returned by the driver.
    /// It also records the final state of the car (odometer, fuel).
    /// </summary>
    /// <param name="finalReading">The odometer reading obtained when the car is returned.</param>
    /// <param name="finalLevel">The fuel level when the car is returned.</param>
    /// <exception cref="InvalidRentalStateException">Thrown if the rental is not 'InProgress'.</exception>
    public void CheckOut(OdometerReading finalReading, FuelLevel finalLevel)
    {
        if (Status != RentalStatus.InProgress)
        {
            throw new InvalidRentalStateException("Cannot check-out a car that is not checked-in.");
        }

        Car.Return(finalReading, finalLevel);

        Status = RentalStatus.Stopped;
        AddDomainEvent(new RentalCheckedOutEvent(Id, Car.Id, PrimaryDriver.Id, finalReading.Value, finalLevel.Value));
    }

    /// <summary>
    /// Closes the rental, marking it as fully completed.
    /// This method enforces the business rule that the balance must be cleared.
    /// 
    /// There are many ways of approaching this:
    /// - DomainObject (Current implementation): Explicit intent, Easy to extend, Semantic Signal
    /// - DomainService: Keeps rental pure, easier to test and isolate policies.
    /// - Passing in balance: Naive approach, leaks upstream semantics
    /// 
    /// Ideally, this becomes a two-step phase:
    /// - InitiateClosure() which raises a domain event RentalClousreInitiatedEvent,
    ///     which is then published as an integration event and the Balance/Billing context
    ///     calculates if theres any balance left and raises BalanceClearedEvent
    /// - BalanceClearedEvent is published as an integration event which we then listen to 
    ///     in order to call rental.Close();
    /// </summary>
    /// <param name="outstandingBalance">The current outstanding balance for the rental.</param>
    /// <exception cref="OutstandingBalanceException">Thrown if the outstanding balance is greater than zero.</exception>
    public void Close(BalanceClearance clearance)
    {
        if (!clearance.Approved)
        {
            throw new OutstandingBalanceException("Cannot close a rental that has outstanding balance");
        }

        Status = RentalStatus.Closed;
        AddDomainEvent(new RentalClosedEvent(Id));
    }

    /// <summary>
    /// Cancels the rental before it starts.
    /// This method enforces the business rule that cancellation is only possible when the rental is 'Open',
    /// and the (physical) contract has not been signed/stamped.
    /// </summary>
    /// <exception cref="InvalidRentalStateException">Thrown if the rental is not in the 'Open' state.</exception>
    public void Cancel()
    {
        if (Status != RentalStatus.Open)
        {
            throw new InvalidRentalStateException("Cannot cancel a rental once it has started.");
        }

        Status = RentalStatus.Cancelled;
        AddDomainEvent(new RentalCancelledEvent(Id, Car.Id));
    }
}