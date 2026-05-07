using CRMWeb.Models.Counterparties;
using FluentValidation;

namespace CRMWeb.Services.Counterparties;

public class CounterpartyValidator : AbstractValidator<CounterpartyModel>
{
    public CounterpartyValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Name).MaximumLength(100).WithMessage("The name must be 100 characters or fewer.");
        //RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name is required");
        //RuleFor(x => x.FullName).MaximumLength(200).WithMessage("The full name must be 200 characters or fewer.");
        //RuleFor(x => x.FormOfOwnership).NotNull().WithMessage("Form of ownership is required");
        //RuleFor(x => x.Edrpou).Must(x => string.IsNullOrEmpty(x) == true || x.Length == 8).WithMessage("The EDRPOU must be 8 characters.");
        //RuleFor(x => x.Tin).Must(x => string.IsNullOrEmpty(x) == true || x.Length == 10).WithMessage("The TIN must be 10 characters or fewer.");
        //RuleFor(x => x.Description).MaximumLength(1000).WithMessage("The description must be 1000 characters or fewer.");
    }
}
