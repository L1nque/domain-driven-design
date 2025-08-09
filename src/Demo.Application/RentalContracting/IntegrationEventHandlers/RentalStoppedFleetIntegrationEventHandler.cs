using Demo.Application.FleetManagement.Commands;
using Demo.Domain.RentalContracting.Events;
using MediatR;

namespace Demo.Application.RentalContracting.IntegrationEventHandlers;

/// <summary>
/// When a rental is stopped (i.e. a car is returned), we need to somehow communicate
/// this to the FleetManagement context (cross-context communication)
/// 
/// Normally, in more distributed systems, we'd publish an integration event to message bus, but
/// in this case since we're working within the same repository, we'll just call the respective command.
/// </summary>
public class RentalStoppedFleetIntegrationEventHandler : INotificationHandler<RentalCheckedOutEvent>
{
    private readonly IMediator _mediator;

    public RentalStoppedFleetIntegrationEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(RentalCheckedOutEvent notification, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CarUpdateMileageCommand(notification.CarId, notification.OdomoterValue));
    }
}