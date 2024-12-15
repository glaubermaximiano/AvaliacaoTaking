using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Taking.Dominio.Entidade
{
    [ExcludeFromCodeCoverage]
    public class ClienteDominio: BaseEntidade
    {
        [Required(ErrorMessage = "A aplicação requer que o campo Nome seja preenchida!")]
        [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caracteres")]
        public string NomCliente { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Telefone seja preenchida!")]
        [StringLength(11, ErrorMessage = "O Telefone deve possuir no máximo 11 caracteres")]
        string _codTelefone;
        public string CodTelefone { 
            get { return long.Parse(_codTelefone).ToString(@"(00) 0000-00000"); }
            set { _codTelefone = value; }
        }

        [Required(ErrorMessage = "A aplicação requer que o campo Endereço seja preenchida!")]
        [StringLength(500, ErrorMessage = "O Endereço deve possuir no máximo 500 caracteres")]
        public string EndCliente { get; set; }
    }
}
