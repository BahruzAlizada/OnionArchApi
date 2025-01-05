using FluentValidation;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Validation.FluentValidation.RoleValidator
{
    public class RoleAddValidator : AbstractValidator<RoleAddDto>
    {
        public RoleAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rol adı boş ola bilməz");
        }
    }
}
