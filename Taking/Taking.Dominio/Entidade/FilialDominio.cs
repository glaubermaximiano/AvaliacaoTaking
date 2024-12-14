using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio.Entidade
{
    [ExcludeFromCodeCoverage]
    public class FilialDominio : BaseEntidade
    {
        [Required(ErrorMessage = "A aplicação requer que o campo Nome seja preenchida!")]
        [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caracteres")]
        public string NomFilial { get; set; }
    }
}
