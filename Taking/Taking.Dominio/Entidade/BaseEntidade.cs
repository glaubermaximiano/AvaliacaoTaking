using System.Diagnostics.CodeAnalysis;
using Taking.Dominio.Validacao;

namespace Taking.Dominio.Entidade
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseEntidade
    {
        public int Id { get; set; }

        [ValidaSituacao]
        public string IdcSituacao { get; set; }

        public string DescSituacao
        {
            get
            {
                return this.IdcSituacao == "A"? "Ativo": "Cancelado";
            }
        }
    }
}
