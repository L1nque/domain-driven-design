namespace Demo.Application.RentalContracting.Queries;

public record RentalByIdResponse(
    Guid Id,
    double DurationInDays
);