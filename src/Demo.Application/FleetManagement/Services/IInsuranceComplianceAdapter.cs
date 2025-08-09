using Demo.Domain.FleetManagement.ValueObjects;

namespace Demo.Application.FleetManagement.Services;

public interface IInsuranceComplianceAdapter
{
    Task<InsuranceCompliance> GetInsuranceCompliance(Guid id);
}