using Demo.Domain.RentalContracting.ValueObjects;
using Demo.SharedKernel.Core.Models;

namespace Demo.Domain.RentalContracting.Events;

public class RentalCancelledEvent : DomainEvent
{
    public RentalId RentalId { get; init; }
    public Guid CarId { get; init; }

    public RentalCancelledEvent(RentalId rentalId, Guid carId)
    {
        RentalId = rentalId;
        CarId = carId;
    }
}