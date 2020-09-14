using System;
using Financial.Bill.Domain.Enums.v1;

namespace Financial.Bill.Domain.ValueObjects.v1
{
    public class PaymentMode
    {
        public PaymentType PaymentType { get; set; }

        public Guid? CardId { get; set; }

        public Guid? FinancialSourceId { get; set; }

        public int? Installments { get; set; }

        public DateTime EffectiveDate { get; set; }

        public bool NotFilled() =>
            EffectiveDate == DateTime.MinValue ||
            !Enum.IsDefined(typeof(PaymentType), PaymentType) ||
            PaymentType == PaymentType.InternetBanking && FinancialSourceId == null ||
            (PaymentType == PaymentType.Credit || PaymentType == PaymentType.Debit) && CardId == null;
    }
}