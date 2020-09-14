using Financial.Bill.Domain.Enums.v1;
using Financial.Bill.Domain.ValueObjects.v1;
using Financial.Framework.Domain.Entities;
using System;

namespace Financial.Bill.Domain.Entities.v1
{
    public class Bill : Entity<Guid>
    {
        public Bill()
        {
            Versioning = new Versioning();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public BillType BillType { get; set; }

        public ExpenseType ExpenseType { get; set; }

        public decimal? Amount { get; set; }

        public PaymentMode PaymentMode { get; set; }

        public FixedBill FixedBill { get; set; }

        public Versioning Versioning { get; set; }

        private bool InvalidName() => string.IsNullOrEmpty(Name);

        private bool InvalidVersioning() 
            => string.IsNullOrEmpty(Versioning?.CreatedBy);

        private bool InvalidBillType()
            => !Enum.IsDefined(typeof(BillType), BillType);

        private bool InvalidExpenseType() 
            => !Enum.IsDefined(typeof(ExpenseType), ExpenseType);

        private bool InvalidAmount() 
            => Amount == null && BillType == BillType.ExpenseSingle;

        private bool InvalidPaymentMode() 
            => BillType == BillType.ExpenseSingle && PaymentMode == null || PaymentMode.NotFilled();

        private bool InvalidFixedBill() 
            => BillType == BillType.MonthlySpend && (FixedBill == null || FixedBill.NotFilled());

        public override bool IsValid()
        {
            if(InvalidName())
                AddNotification("Bill.InvalidName");

            if(InvalidVersioning())
                AddNotification("Bill.InvalidVersioning");

            if(InvalidBillType())
                AddNotification("Bill.InvalidType");

            if(InvalidExpenseType())
                AddNotification("Bill.InvalidExpenseType");

            if(InvalidAmount())
                AddNotification("Bill.InvalidAmount");

            if(InvalidPaymentMode())
                AddNotification("Bill.InvalidPaymentMode");

            if(InvalidFixedBill())
                AddNotification("Bill.InvalidFixedBill");

            return !HasNotifications();
        }
    }
}