using Financial.Bill.Domain.Enums.v1;
using Financial.Framework.Domain.Entities;
using System;

namespace Financial.Bill.Domain.Commands.v1.BillAdd
{
    public class BillAddCommand : Command<bool>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public BillType BillType { get; set; }

        public ExpenseType ExpenseType { get; set; }

        public decimal Amount { get; set; }

        public PaymentType PaymentType { get; set; }

        public Guid? CardId { get; set; }

        public Guid? FinancialSourceId { get; set; }

        public int? InstallmentsPayment { get; set; }

        public DateTime EffectiveDate { get; set; }

        public int? InstallmentsFixedBill { get; set; }

        public decimal? BaseFixedValue { get; set; }

        public bool MonthlyConfirmation { get; set; }

        public int DueDay { get; set; }

        public string LoggedUser { get; set; }
    }
}