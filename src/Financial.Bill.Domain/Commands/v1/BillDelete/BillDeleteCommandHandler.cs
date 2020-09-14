using Financial.Bill.Domain.Enums.v1;
using Financial.Framework.Domain.Entities;
using Financial.Framework.Domain.Handlers;
using Financial.Framework.Domain.Interfaces;
using Financial.Framework.Infra.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Financial.Bill.Domain.Commands.v1.BillDelete
{
    public class BillDeleteCommandHandler : CommandHandler<BillDeleteCommandHandler>, IRequestHandler<BillDeleteCommand, Unit>
    {
        private readonly IBaseRepository<Entities.v1.Bill> _billRepository;

        public BillDeleteCommandHandler(INotificationService notificationService, 
                                        ILogger<BillDeleteCommandHandler> logger,
                                        IBaseRepository<Entities.v1.Bill> billRepository) : base(notificationService, logger)
        {
            _billRepository = billRepository;
        }

        public async Task<Unit> Handle(BillDeleteCommand request, CancellationToken cancellationToken)
        {
            var bill = await _billRepository.GetByIdAsync(request.Id);

            if (bill == null)
            {
                NotificationService.Push(new Notification("Bill.NotFound"));
                return await Unit.Task;
            }

            if (bill.BillType == BillType.MonthlySpend && bill.FixedBill.Active)
                NotificationService.Push(new Notification("Bill.NotDeleteActive"));
            else
            {
                bill.Exclude();
                bill.Versioning
                    .SetModifiedVersion(request.LoggedUser);

                await _billRepository.UpdateAsync(bill);
            }

            return await Unit.Task;
        }
    }
}