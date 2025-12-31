using System.ComponentModel.DataAnnotations;
using KAppraisal.Enums;

namespace KAppraisal.Rules
{
    public class TodoStatusValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is not string stringValue)
            {
                return new ValidationResult("Status harus berupa string.");
            }

            if (!Enum.TryParse<TodoStatus>(
                    stringValue,
                    true,
                    out _))
            {
                return new ValidationResult(
                    $"Status '{stringValue}' tidak valid.");
            }

            return ValidationResult.Success;
        }

    }
}