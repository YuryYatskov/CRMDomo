using CRMWeb.Models.Phones;
using FluentValidation;

namespace CRMWeb.Services.Phones;

public class PhoneValidator : AbstractValidator<PhoneModel>
{
    public PhoneValidator()
    {
        //RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}
