using Financial.Framework.Domain.Entities;
using System;

namespace Financial.Bill.Domain.Commands.v1.BillDeactivate
{
    public class BillDeactivateCommand : Command<bool>
    {
        public Guid Id { get; set; }

        public bool RemoveScheduledSpend { get; set; }

        public DateTime? DeleteFromDate { get; set; }

        public string LoggedUser { get; set; }

        public BillDeactivateCommand SetId(Guid id)
        {
            Id = id;

            return this;
        }
    }
}