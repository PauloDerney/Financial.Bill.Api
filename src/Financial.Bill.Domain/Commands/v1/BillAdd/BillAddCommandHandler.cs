using AutoMapper;
using Financial.Bill.Domain.Events.v1.BillAdd;
using Financial.Framework.Domain.Handlers;
using Financial.Framework.Domain.Interfaces;
using Financial.Framework.Infra.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Financial.Bill.Domain.Commands.v1.BillAdd
{
    public class BillAddCommandHandler : CommandHandler<BillAddCommandHandler>, IRequestHandler<BillAddCommand, bool>
    {
        private readonly IBaseRepository<Entities.v1.Bill> _accountRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public BillAddCommandHandler(INotificationService notificationService, 
                                     ILogger<BillAddCommandHandler> logger,
                                     IBaseRepository<Entities.v1.Bill> accountRepository,
                                     IMediator mediator,
                                     IMapper mapper) : base(notificationService, logger)
        {
            _accountRepository = accountRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<bool> Handle(BillAddCommand request, CancellationToken cancellationToken)
        {
            Logger.LogDebug("[AddAccountCommandHandler] Request received: {@request}", request);

            var bill = _mapper.Map<Entities.v1.Bill>(request);

            bill.Versioning.SetCreatedVersion(request.LoggedUser);
            
            if (bill.IsValid())
            {
                Logger.LogDebug("[AddAccountCommandHandler] Inserting account: {@account}", bill);

                await _accountRepository.InsertAsync(bill);
                await _mediator.Publish(new BillAddEvent(bill, request.CorrelationId), cancellationToken);

                return true;
            }

            Logger.LogWarning("[AddAccountCommandHandler] Invalid request: {@account}", bill);

            NotificationService.Push(bill.GetNotifications());

            return false;
        }
    }
}
