using Financial.Bill.Domain.Enums.v1;
using Financial.Bill.Domain.Events.v1.BillDeactivate;
using Financial.Framework.Domain.Entities;
using Financial.Framework.Domain.Handlers;
using Financial.Framework.Domain.Interfaces;
using Financial.Framework.Infra.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Financial.Bill.Domain.Commands.v1.BillDeactivate
{
    public class BillDeactivateCommandHandler : CommandHandler<BillDeactivateCommandHandler>, IRequestHandler<BillDeactivateCommand, bool>
    {
        private readonly IBaseRepository<Entities.v1.Bill> _billRepository;
        private readonly IMediator _mediator;

        public BillDeactivateCommandHandler(INotificationService notificationService,
                                            ILogger<BillDeactivateCommandHandler> logger,
                                            IBaseRepository<Entities.v1.Bill> billRepository,
                                            IMediator mediator) : base(notificationService, logger)
        {
            _billRepository = billRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(BillDeactivateCommand request, CancellationToken cancellationToken)
        {
            var bill = await _billRepository.GetByIdAsync(request.Id);

            if (bill == null)
            {
                NotificationService.Push(new Notification("Bill.NotFound"));
                return await Task.FromResult(false);
            }

            if (bill.BillType == BillType.MonthlySpend)
            {
                bill.FixedBill.Deactivate();
                bill.Versioning.SetModifiedVersion(request.LoggedUser);

                await _billRepository.UpdateAsync(bill);
                await _mediator.Publish(new BillDeactivateEvent(bill, request.CorrelationId), cancellationToken);

                return await Task.FromResult(true);
            }

            NotificationService.Push(new Notification("BillDeactivate.InvalidBillType"));

            return await Task.FromResult(false);
        }
    }
}