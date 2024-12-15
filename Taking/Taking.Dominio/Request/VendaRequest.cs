using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio.Request
{
    [ExcludeFromCodeCoverage]
    public class VendaRequest
    {
        public DateTime DthVenda { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A aplicação requer que o campo Cliente seja preenchido!")]
        public int NumCliente { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A aplicação requer que o campo Filial seja preenchido!")]
        public int NumFilial { get; set; }
    }
}
