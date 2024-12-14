using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio.Entidade
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseEntidade
    {
        public int Id { get; set; }

        public string IdcSituacao { get; set; }

        public string DescSituacao
        {
            get
            {
                return this.IdcSituacao == "A"? "Ativo": "Inativo";
            }
        }
    }
}
