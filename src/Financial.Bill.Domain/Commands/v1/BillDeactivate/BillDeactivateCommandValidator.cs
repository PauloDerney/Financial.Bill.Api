using FluentValidation;

namespace Financial.Bill.Domain.Commands.v1.BillDeactivate
{
    public class BillDeactivateCommandValidator : AbstractValidator<BillDeactivateCommand>
    {
        public BillDeactivateCommandValidator()
        {
            RuleFor(bill => bill.Id)
                .NotEmpty();

            RuleFor(bill => bill.DeleteFromDate)
                .NotEmpty()
                .Must((bill, date) => bill.RemoveScheduledSpend);

        }
    }
}