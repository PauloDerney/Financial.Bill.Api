using Financial.Framework.Infra.Data.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Financial.Bill.Domain.Queries.v1.BillSearchPaginated
{
    public class BillSearchPaginatedQueryHandler : IRequestHandler<BillSearchPaginatedQuery, object>
    {
        private readonly IBaseRepository<Entities.v1.Bill> _billRepository;

        public BillSearchPaginatedQueryHandler(IBaseRepository<Entities.v1.Bill> billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<object> Handle(BillSearchPaginatedQuery request, CancellationToken cancellationToken)
        {

            var items = await _billRepository.GetPaginatedResultAsync(x => !x.Excluded, request.OffSet, request.Limit).ConfigureAwait(false);
            var total = await _billRepository.CountAsync(x => !x.Excluded);

            return new
            {
                items = items.Select(item => new BillSearchPaginatedQueryModel(item)), total
            };
        }
    }
}