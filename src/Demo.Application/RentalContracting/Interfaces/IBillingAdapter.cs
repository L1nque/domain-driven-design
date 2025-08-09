using Demo.Domain.RentalContracting.ValueObjects;

namespace Demo.Application.RentalContracting.Interfaces;

public interface IBillingAdapter
{
    Task<BalanceClearance> GetClearance(RentalId rentalId);
}