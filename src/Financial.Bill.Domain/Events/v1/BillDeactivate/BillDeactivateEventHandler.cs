using Financial.Framework.Domain.Handlers;
using Financial.Framework.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Financial.Bill.Domain.Events.v1.BillDeactivate
{
    public class BillDeactivateEventHandler : EventHandler<BillDeactivateEventHandler>, INotificationHandler<BillDeactivateEvent>
    {
        public BillDeactivateEventHandler(IMessageQueueService messageQueueService, ILogger<BillDeactivateEventHandler> logger) : base(messageQueueService, logger)
        {
        }

        public async Task Handle(BillDeactivateEvent notification, CancellationToken cancellationToken)
        {
            Logger.LogDebug("[AddAccountEventHandler] Send notification to topic new-bill Notification: {@notification}", notification);

            await MessageQueueService.PublishAsync(notification, "bill-deactivate", cancellationToken);
        }
    }
}