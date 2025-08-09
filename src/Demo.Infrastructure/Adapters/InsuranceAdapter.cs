using Demo.Application.FleetManagement.Services;
using Demo.Domain.FleetManagement.ValueObjects;

namespace Demo.Infrastructure.Adapters;

/// <summary>
/// Just a mock implementation.
/// </summary>
public class InsuranceAdapter : IInsuranceComplianceAdapter
{
    public async Task<InsuranceCompliance> GetInsuranceCompliance(Guid id)
    {
        var insurance = new InsuranceCompliance(Guid.CreateVersion7(), Guid.CreateVersion7().ToString(), DateTime.UtcNow.AddYears(1));
        return await Task.FromResult(insurance);
    }
}