using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public string NotEmptyMesssage { get; } = "{PropertyName} alanı boş olamaz";
        public AddressValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage(NotEmptyMesssage);
            RuleFor(x => x.Province).NotEmpty().WithMessage(NotEmptyMesssage);
            RuleFor(x => x.PostCode).NotEmpty().WithMessage(NotEmptyMesssage)
                .MaximumLength(5).WithMessage("{PropertyName} alanı en fazla   {MaxLength} olabilir.");
        }
    }
}
