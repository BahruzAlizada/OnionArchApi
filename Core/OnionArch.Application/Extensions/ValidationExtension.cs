
using FluentValidation.Results;

namespace OnionArch.Application.Extensions.FluentValidationExtension
{
    public static class ValidationExtension
    {
        public static string ValidationErrorString(this ValidationResult validationResult)
        {
            return string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
