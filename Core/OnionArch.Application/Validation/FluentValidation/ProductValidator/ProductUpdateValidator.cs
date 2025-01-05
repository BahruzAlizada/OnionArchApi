using FluentValidation;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Validation.FluentValidation.ProductValidator
{
    public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Məhsul adı boş ola bilməz");
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stok o-dan kiçik ola bilməz");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Məhsulun qiyməti 0-dan kiçik ola bilməz");
        }
    }
}
