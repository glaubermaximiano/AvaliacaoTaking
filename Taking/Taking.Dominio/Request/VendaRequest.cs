using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio.Request
{
    [ExcludeFromCodeCoverage]
    public class VendaRequest
    {
        public VendaRequest()
        {
            this.Items = new List<VendaItemRequest>();
        }

        public DateTime DthVenda { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A aplicação requer que o campo Cliente seja preenchido!")]
        public int ClienteId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A aplicação requer que o campo Filial seja preenchido!")]
        public int FilialId { get; set; }

        public List<VendaItemRequest> Items { get; set; }
    }
}
