using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio.Entidade
{
    [ExcludeFromCodeCoverage]
    public class ProdutoDominio: BaseEntidade
    {
        [Required(ErrorMessage = "A aplicação requer que o campo Código seja preenchida!")]
        [StringLength(15, ErrorMessage = "O Código deve possuir no máximo 15 caracteres")]
        public string CodProduto { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Nome seja preenchida!")]
        [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caracteres")]
        public string NomProduto { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Descrição seja preenchida!")]
        [StringLength(500, ErrorMessage = "A Descrição deve possuir no máximo 500 caracteres")]
        public string DescProduto { get; set; }

        [Range(0.01, 999999, ErrorMessage = "Os Valores devem ser R$ 0,01 e R$ 999.999")]
        public decimal ValPrecoUnitario { get; set; }
    }
}
