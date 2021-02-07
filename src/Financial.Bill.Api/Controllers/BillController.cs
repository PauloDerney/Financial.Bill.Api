using Financial.Bill.Domain.Commands.v1.BillAdd;
using Financial.Bill.Domain.Commands.v1.BillDeactivate;
using Financial.Bill.Domain.Commands.v1.BillDelete;
using Financial.Bill.Domain.Queries.v1.BillSearchPaginated;
using Financial.Framework.Api;
using Financial.Framework.Domain.Interfaces;
using Financial.Framework.Infra.Data.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Financial.Bill.Api.Controllers
{
    [Route("api/v1/bills")]
    public class BillController : RestApi<BillController>
    {
        private readonly IBaseRepository<Domain.Entities.v1.Bill> _billRepository;

        public BillController(IMediator mediator,
                              INotificationService notificationService,
                              ILogger<BillController> logger,
                              IBaseRepository<Domain.Entities.v1.Bill> billRepository)
            : base(mediator, notificationService, logger)
        {
            _billRepository = billRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]BillAddCommand command) => await GetResultAsync(command, HttpStatusCode.Created);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id) => await GetResultAsync(async () => await _billRepository.GetByIdAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => await GetResultAsync(new BillSearchPaginatedQuery());

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id) => await GetResultAsync(new BillDeleteCommand(id));

        [HttpPatch("{id}")]
        public async Task<IActionResult> DeactivateAsync(Guid id, [FromBody] BillDeactivateCommand request) => await GetResultAsync(request.SetId(id));
    }
}