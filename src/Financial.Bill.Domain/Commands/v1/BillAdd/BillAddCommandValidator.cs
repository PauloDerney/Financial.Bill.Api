using FluentValidation;

namespace Financial.Bill.Domain.Commands.v1.BillAdd
{
    public class BillAddCommandValidator : AbstractValidator<BillAddCommand>
    {
        public BillAddCommandValidator()
        {
            RuleFor(bill => bill.Name)
                .NotEmpty();

            RuleFor(bill => bill.BillType)
                .NotEmpty();

            RuleFor(bill => bill.EffectiveDate)
                .NotEmpty();

            RuleFor(bill => bill.DueDay)
                .NotEmpty();

            RuleFor(bill => bill.ExpenseType)
                .NotEmpty();
        }
    }
}