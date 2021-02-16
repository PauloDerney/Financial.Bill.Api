using Financial.Framework.Domain.Handlers;
using Financial.Framework.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Financial.Bill.Domain.Events.v1.BillAdd
{
    public class BillAddEventHandler : EventHandler<BillAddEventHandler>, INotificationHandler<BillAddEvent>
    {
        public BillAddEventHandler(IPublisherService messageQueueService, ILogger<BillAddEventHandler> logger) : base(messageQueueService, logger)
        {
        }

        public async Task Handle(BillAddEvent notification, CancellationToken cancellationToken)
        {
            Logger.LogDebug("[AddAccountEventHandler] Send notification to topic new-bill Notification: {@notification}", notification);

            await MessageQueueService.PublishAsync(notification, "new-bill", cancellationToken);
        }
    }
}