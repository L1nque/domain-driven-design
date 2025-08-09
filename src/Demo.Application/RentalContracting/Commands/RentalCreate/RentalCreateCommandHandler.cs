using Demo.Application.Common.Exceptions;
using Demo.Application.RentalContracting.Interfaces;
using Demo.Domain.RentalContracting;
using Demo.Domain.RentalContracting.ValueObjects;
using Demo.SharedKernel.Core.Abstractions;
using Demo.SharedKernel.Types;
using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public class RentalCreateCommandHandler : IRequestHandler<RentalCreateCommand, RentalCreateCommandResponse>
{
    private readonly IRepository<Rental, RentalId> _repository;
    private readonly IFleetAdapter _fleetAdapter;
    private readonly IDriverAdapter _driverAdapter;

    public RentalCreateCommandHandler(IRepository<Rental, RentalId> repository, IFleetAdapter fleetAdapter, IDriverAdapter driverAdapter)
    {
        _repository = repository;
        _fleetAdapter = fleetAdapter;
        _driverAdapter = driverAdapter;
    }

    public async Task<RentalCreateCommandResponse> Handle(RentalCreateCommand request, CancellationToken cancellationToken = default)
    {
        var car = await _fleetAdapter.GetCarForRental(RentalCarId.Create(request.CarId));
        var driver = await _driverAdapter.GetDriver(DriverId.Create(request.DriverId));

        NotFoundException.ThrowIfNull(car);
        NotFoundException.ThrowIfNull(driver);

        var rentalPeriod = new RentalPeriod(new DateRange(request.StartDate, request.EndDate));
        var rental = new Rental(RentalId.Create(Guid.CreateVersion7()), car, driver, rentalPeriod);


        await _repository.AddAsync(rental, cancellationToken);
        return new RentalCreateCommandResponse(rental.Id);
    }
}