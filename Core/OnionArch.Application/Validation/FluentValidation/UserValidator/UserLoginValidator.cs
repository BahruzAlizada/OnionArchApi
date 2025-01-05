using FluentValidation;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Validation.FluentValidation.UserValidator
{
    public class UserLoginValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(x=>x.Email)
                .NotEmpty().WithMessage("bu xana boş ola bilməz")
                .EmailAddress().WithMessage("Email adresini düzgün qeyd etmək vacibdir");
            RuleFor(x => x.Password)

                .NotEmpty().WithMessage("bu xana boş ola bilməz");
        }
    }
}
