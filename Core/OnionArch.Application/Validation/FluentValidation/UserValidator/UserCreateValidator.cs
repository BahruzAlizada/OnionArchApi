
using FluentValidation;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Validation.FluentValidation.UserValidator
{
    public class UserCreateValidator : AbstractValidator<UserAddDto>
    {
        //public UserCreateValidator()
        //{
        //    RuleFor(x => x.FullName)
        //        .NotEmpty().WithMessage();

        //    RuleFor(x => x.UserName)
        //        .NotEmpty().WithMessage();
        //}
    }
}
