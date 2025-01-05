using FluentValidation;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Validation.FluentValidation.RoleValidator
{
    public class RoleUpdateValidator : AbstractValidator<RoleUpdateDto>
    {
        public RoleUpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rol adı boş ola bilməz");
        }
    }
}
