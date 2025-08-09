using Demo.Application.RentalContracting.Interfaces;
using Demo.Domain.RentalContracting.ValueObjects;

namespace Demo.Infrastructure.Adapters;

/// <summary>
/// Just a mock implementation
/// </summary>
internal class BillingAdapter : IBillingAdapter
{
    public Task<BalanceClearance> GetClearance(RentalId rentalId)
    {
        return Task.FromResult(new BalanceClearance(true));
    }
}