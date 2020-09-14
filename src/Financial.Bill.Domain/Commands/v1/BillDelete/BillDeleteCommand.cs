using MediatR;
using System;

namespace Financial.Bill.Domain.Commands.v1.BillDelete
{
    public class BillDeleteCommand : IRequest<Unit>
    {
        public BillDeleteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public string LoggedUser { get; set; }
    }
}