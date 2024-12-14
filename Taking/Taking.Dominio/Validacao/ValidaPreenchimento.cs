using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio.Validacao
{
    [ExcludeFromCodeCoverage]
    public static class ValidaPreenchimento
    {
        public static string Validar<T>(T model)
        {
            var results = new List<ValidationResult>();

            var validationContext = new ValidationContext(model, null, null);

            Validator.TryValidateObject(model, validationContext, results, true);

            if (model is IValidatableObject)
                (model as IValidatableObject).Validate(validationContext);

            return results.Count == 0 ? string.Empty : results.ToList().FirstOrDefault().ErrorMessage;
        }
    }
}
