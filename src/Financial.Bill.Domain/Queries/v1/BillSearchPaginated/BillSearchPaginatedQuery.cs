using MediatR;

namespace Financial.Bill.Domain.Queries.v1.BillSearchPaginated
{
    public class BillSearchPaginatedQuery : IRequest<object>
    {
        public int OffSet { get; set; }

        public int Limit { get; set; }
    }
}