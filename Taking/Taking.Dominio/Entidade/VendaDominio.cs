using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio.Entidade
{
    [ExcludeFromCodeCoverage]
    public class VendaDominio : BaseEntidade
    {
        public int CodVenda { get; set; }

        public DateTime DthVenda { get; set; }

        public int ClienteId { get; set; }

        public int FilialId { get; set; }
    }
}
