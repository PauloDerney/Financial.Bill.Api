using FluentValidation;

namespace Financial.Bill.Domain.Commands.v1.BillDelete
{
    public class BillDeleteCommandValidator : AbstractValidator<BillDeleteCommand>
    {
        public BillDeleteCommandValidator()
        {
            RuleFor(bill => bill.Id)
                .NotEmpty();
        }
    }
}