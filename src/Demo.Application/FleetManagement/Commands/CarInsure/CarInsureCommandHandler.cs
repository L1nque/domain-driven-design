using Demo.Application.Common.Exceptions;
using Demo.Application.FleetManagement.Services;
using Demo.Domain.FleetManagement;
using Demo.Domain.FleetManagement.ValueObjects;
using Demo.SharedKernel.Core.Abstractions;
using MediatR;

namespace Demo.Application.FleetManagement.Commands;

public class CarInsureCommandHandler : IRequestHandler<CarInsureCommand>
{
    private readonly IRepository<Car, CarId> _repository;
    private readonly IInsuranceComplianceAdapter _insuranceAdapter;

    public CarInsureCommandHandler(IRepository<Car, CarId> repository, IInsuranceComplianceAdapter insuranceAdapter)
    {
        _repository = repository;
        _insuranceAdapter = insuranceAdapter;
    }

    public async Task Handle(CarInsureCommand request, CancellationToken cancellationToken)
    {
        var insurance = await _insuranceAdapter.GetInsuranceCompliance(request.InsuranceId);
        NotFoundException.ThrowIfNull(insurance);

        var car = await _repository.GetByIdAsync(new CarId(request.Id));
        NotFoundException.ThrowIfNull(car);

        car.InsureCar(insurance);
        await _repository.UpdateAsync(car);
    }
}