

using FluentValidation;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Validation.FluentValidation.UserValidator
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş ola bilməz")
                .EmailAddress().WithMessage("Emaili düzgün daxil etmək lazımdır");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username boş ola bilməz");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Ad və Soyad boş ola bilməz");
        }
    }
}
