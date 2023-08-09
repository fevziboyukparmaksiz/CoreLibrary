using FluentValidation;
using FluentValidation.Results;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMEsssage { get; } = "{PropertyName} alanı boş olamaz";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMEsssage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMEsssage)
                .EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMEsssage)
                .InclusiveBetween(18, 60).WithMessage("Age alanı 18 ile 60 arasında olmalıdır");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage(NotEmptyMEsssage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;

            }).WithMessage("Yaşınız 18'den büyük olmalıdır");

            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
        }
    }
}
