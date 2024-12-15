using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio.Validacao
{
    [ExcludeFromCodeCoverage]
    public class ValidaSituacao : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext contex)
        {
            if (value != null)
            {
                if (!(new List<string>() { "A", "I" }).Contains(value.ToString()))
                {
                    return new ValidationResult("Situação inválida!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
