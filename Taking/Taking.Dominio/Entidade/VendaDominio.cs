using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio.Entidade
{
    [ExcludeFromCodeCoverage]
    public class VendaDominio : BaseEntidade
    {
        public string CodVenda { get; set; }

        public DateTime DthVenda { get; set; }

        public int NumCliente { get; set; }

        public int NumFilial { get; set; }
    }
}
