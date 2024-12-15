using Moq;
using System.Diagnostics.CodeAnalysis;
using Taking.Aplicacao.Servico;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Servico;
using Taking.Dominio.Validacao;

namespace Taking.Aplicacao.Teste
{
    [ExcludeFromCodeCoverage]
    public class ProdutoTeste
    {
        [Fact]
        public void ValidaPreenchimento_Ok()
        {
            var _obj = new ProdutoDominio { 
                                            CodProduto = "PRD001", 
                                            NomProduto = "Produto I", 
                                            DescProduto = "Meu Produto de Teste I",
                                            ValPrecoUnitario = 50,
                                            IdcSituacao = "A" 
                                          };

            var _msg = ValidaPreenchimento.Validar(_obj);

            Assert.True(string.IsNullOrEmpty(_msg));
        }

        [Fact]
        public void ValidaPreenchimento_NaoOk()
        {
            var _obj = new ProdutoDominio
            {
                CodProduto = string.Empty,
                NomProduto = "Produto I",
                DescProduto = "Meu Produto de Teste I",
                ValPrecoUnitario = 50,
                IdcSituacao = "A"
            };

            var _msg = ValidaPreenchimento.Validar(_obj);

            Assert.True(!string.IsNullOrEmpty(_msg));
        }

        [Fact]
        public void ListaTodos_Ok()
        {
            var _lstProduto = new List<ProdutoDominio>()
            {
                new ProdutoDominio { CodProduto = "PRD001", NomProduto = "Produto I", DescProduto = "Meu Produto de Teste I", ValPrecoUnitario = 50, IdcSituacao = "A" },
                new ProdutoDominio { CodProduto = "PRD002", NomProduto = "Produto II", DescProduto = "Meu Produto de Teste II", ValPrecoUnitario = 25, IdcSituacao = "A" }
            };

            var _servico = new Mock<IProdutoServico>();
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstProduto);

            var _app = new ProdutoAppServico(_servico.Object).ListaTodos("T");

            Assert.True(_app.Count() != 0);
        }

        [Fact]
        public void ListaTodos_VazioOk()
        {
            var _lstProduto = new List<ProdutoDominio>();

            var _servico = new Mock<IProdutoServico>();
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstProduto);

            var _app = new ProdutoAppServico(_servico.Object).ListaTodos("T");

            Assert.True(_app.Count() == 0);
        }

        [Fact]
        public void BuscaPorId_Ok()
        {
            var _objProduto = new ProdutoDominio { Id = 1, CodProduto = "PRD001", NomProduto = "Produto I", DescProduto = "Meu Produto de Teste I", ValPrecoUnitario = 50, IdcSituacao = "A" };

            var _servico = new Mock<IProdutoServico>();
            _servico.Setup(s => s.BuscaPorId(It.IsAny<int>())).Returns(_objProduto);

            var _app = new ProdutoAppServico(_servico.Object).BuscaPorId(It.IsAny<int>());

            Assert.True(_app != null);
        }

        [Fact]
        public void BuscaPeloCodigo_Ok()
        {
            var _objProduto = new ProdutoDominio { Id = 1, CodProduto = "PRD001", NomProduto = "Produto I", DescProduto = "Meu Produto de Teste I", ValPrecoUnitario = 50, IdcSituacao = "A" };

            var _servico = new Mock<IProdutoServico>();
            _servico.Setup(s => s.BuscaPeloCodigo(It.IsAny<string>())).Returns(_objProduto);

            var _app = new ProdutoAppServico(_servico.Object).BuscaPeloCodigo(It.IsAny<string>());

            Assert.True(_app != null);
        }

        [Fact]
        public void Add_Ok()
        {
            var _objProduto = new ProdutoDominio { Id = 1, CodProduto = "PRD001", NomProduto = "Produto I", DescProduto = "Meu Produto de Teste I", ValPrecoUnitario = 50, IdcSituacao = "A" };

            var _lstProduto = new List<ProdutoDominio>()
            {
                new ProdutoDominio { Id = 2, CodProduto = "PRD001", NomProduto = "Produto II", DescProduto = "Meu Produto de Teste II", ValPrecoUnitario = 20, IdcSituacao = "A" },
                new ProdutoDominio { Id = 3, CodProduto = "PRD001", NomProduto = "Produto III", DescProduto = "Meu Produto de Teste III", ValPrecoUnitario = 15, IdcSituacao = "A" }
            };

            var _servico = new Mock<IProdutoServico>();

            _servico.Setup(s => s.Add(_objProduto)).Returns(string.Empty);
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstProduto);

            var _app = new ProdutoAppServico(_servico.Object).Add(_objProduto);

            Assert.True(string.IsNullOrEmpty(_app));
        }

        [Fact]
        public void Add_RegistroJaCadastradoOk()
        {
            var _objProduto = new ProdutoDominio { Id = 1, CodProduto = "PRD001", NomProduto = "Produto I", DescProduto = "Meu Produto de Teste I", ValPrecoUnitario = 50, IdcSituacao = "A" };

            var _servico = new Mock<IProdutoServico>();

            _servico.Setup(s => s.Add(_objProduto)).Returns(string.Empty);
            _servico.Setup(s => s.BuscaPeloCodigo(It.IsAny<string>())).Returns(_objProduto);

            var _app = new ProdutoAppServico(_servico.Object).Add(_objProduto);

            Assert.True(!string.IsNullOrEmpty(_app));
        }

        [Fact]
        public void Update_Ok()
        {
            var _objProduto = new ProdutoDominio { Id = 1, CodProduto = "PRD001", NomProduto = "Produto I", DescProduto = "Meu Produto de Teste I", ValPrecoUnitario = 50, IdcSituacao = "A" };

            var _lstProduto = new List<ProdutoDominio>()
            {
                new ProdutoDominio { Id = 2, CodProduto = "PRD001", NomProduto = "Produto II", DescProduto = "Meu Produto de Teste II", ValPrecoUnitario = 20, IdcSituacao = "A" },
                new ProdutoDominio { Id = 3, CodProduto = "PRD001", NomProduto = "Produto III", DescProduto = "Meu Produto de Teste III", ValPrecoUnitario = 15, IdcSituacao = "A" }
            };

            var _servico = new Mock<IProdutoServico>();

            _servico.Setup(s => s.Update(_objProduto)).Returns(string.Empty);
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstProduto);

            var _app = new ProdutoAppServico(_servico.Object).Update(_objProduto);

            Assert.True(string.IsNullOrEmpty(_app));
        }

        [Fact]
        public void Excliu_Ok()
        {
            var _servico = new Mock<IProdutoServico>();

            _servico.Setup(s => s.Remove(It.IsAny<int>())).Returns(string.Empty);

            var _app = new ProdutoAppServico(_servico.Object).Remove(It.IsAny<int>());

            Assert.True(string.IsNullOrEmpty(_app));
        }
    }
}
