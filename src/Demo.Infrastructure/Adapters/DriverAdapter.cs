using Demo.Application.Common.Exceptions;
using Demo.Application.RentalContracting.Interfaces;
using Demo.Domain.CustomerRelations.Enums;
using Demo.Domain.RentalContracting.Entities;
using Demo.Domain.RentalContracting.ValueObjects;
using Demo.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Adapters;

internal class DriverAdapter : IDriverAdapter
{
    private readonly AppDbContext _dbContext;

    public DriverAdapter(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Driver> GetDriver(DriverId id)
    {
        var customer = await _dbContext.Customers
            .Include(customer => customer.Documents.Where(document => document.Type == (int)IdentityDocumentType.DriversLicense))
            .FirstOrDefaultAsync(customer => customer.Id == id.Value);
        NotFoundException.ThrowIfNull(customer);

        var license = customer.Documents.First();

        return new Driver(
            id: DriverId.Create(id),
            dateOfBirth: customer.DateOfBirth.ToDateTime(TimeOnly.MinValue),
            licenseIssueDate: license.IssueDate.ToDateTime(TimeOnly.MinValue),
            licenseExpiryDate: license.ExpiryDate.ToDateTime(TimeOnly.MinValue)
        );
    }
}