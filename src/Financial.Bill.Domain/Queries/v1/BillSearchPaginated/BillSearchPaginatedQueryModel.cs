using Financial.Bill.Domain.Enums.v1;
using System;

namespace Financial.Bill.Domain.Queries.v1.BillSearchPaginated
{
    public class BillSearchPaginatedQueryModel
    {
        public BillSearchPaginatedQueryModel(Entities.v1.Bill bill)
        {
            Id = bill.Id;
            Name = bill.Name;
            BillType = bill.BillType;
            ExpenseType = bill.ExpenseType;
            Amount = bill.Amount ?? bill.FixedBill?.BaseValue ?? 0;
            Active = bill.FixedBill?.Active ?? false;
            DeleteAllowed = BillType == BillType.ExpenseSingle || !Active;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public BillType BillType { get; set; }

        public ExpenseType ExpenseType { get; set; }

        public decimal Amount { get; set; }

        public bool Active { get; set; }

        public bool DeleteAllowed { get; set; }
    }
}