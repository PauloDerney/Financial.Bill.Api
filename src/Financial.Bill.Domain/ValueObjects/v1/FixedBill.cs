namespace Financial.Bill.Domain.ValueObjects.v1
{
    public class FixedBill
    {
        public int Installments { get; set; }

        public decimal BaseValue { get; set; }

        public bool MonthlyConfirmation { get; set; }

        public int DueDay { get; set; }

        public bool Active { get; set; } = true;

        public void Deactivate() => Active = false;

        public bool NotFilled() => Installments <= 0 || BaseValue <= 0 || DueDay <= 0 || DueDay > 31;
    }
}