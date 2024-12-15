using Moq;
using System.Diagnostics.CodeAnalysis;
using Taking.Aplicacao.Interface;
using Taking.Aplicacao.Servico;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Servico;
using Taking.Dominio.Request;
using Taking.Dominio.Response;
using Taking.Dominio.Servico;
using Taking.Dominio.Validacao;

namespace Taking.Aplicacao.Teste
{
    [ExcludeFromCodeCoverage]
    public class VendaTeste
    {
        [Fact]
        public void ValidaPreenchimento_Ok()
        {
            var _obj = new VendaRequest
            {
                DthVenda = DateTime.Now,
                FilialId = 1,
                ClienteId = 1
            };

            var _msg = ValidaPreenchimento.Validar(_obj);

            Assert.True(string.IsNullOrEmpty(_msg));
        }

        [Fact]
        public void ValidaPreenchimento_NaoOk()
        {
            var _obj = new VendaRequest
            {
                DthVenda = DateTime.Now,
                FilialId = 1,
                ClienteId = 0
            };

            var _msg = ValidaPreenchimento.Validar(_obj);

            Assert.True(!string.IsNullOrEmpty(_msg));
        }

        [Fact]
        public void ListaPorDatas_Ok()
        {
            var _objVenda = new VendaDominio() { Id = It.IsAny<int>(), ClienteId = It.IsAny<int>(), CodVenda = It.IsAny<int>(), DthVenda = It.IsAny<DateTime>(), IdcSituacao = It.IsAny<string>() };

            var _lstVendaPorData = new List<VendaDominio>()
            {
                _objVenda
            };

            var _servico = new Mock<IVendaServico>();
            _servico.Setup(s => s.BuscaPorData(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_lstVendaPorData);
            _servico.Setup(s => s.BuscaPeloCodigo(It.IsAny<int>())).Returns(_objVenda);

            var _vendaItem = new Mock<IVendaItemAppServico>();
            _vendaItem.Setup(s => s.ListaTodos(It.IsAny<int>())).Returns(new List<VendaItemResponse>());

            var _app = new VendaAppServico(new Mock<IClienteServico>().Object,
                                           new Mock<IFilialServico>().Object,
                                           _servico.Object,
                                           _vendaItem.Object).BuscaPorData(It.IsAny<DateTime>(), It.IsAny<DateTime>());

            Assert.True(_app.Count() != 0);
        }

        [Fact]
        public void BuscaPeloCodigo_Ok()
        {
            var _objVenda = new VendaDominio() { Id = It.IsAny<int>(), ClienteId = It.IsAny<int>(), CodVenda = It.IsAny<int>(), DthVenda = It.IsAny<DateTime>(), IdcSituacao = It.IsAny<string>() };

            var _servico = new Mock<IVendaServico>();
            _servico.Setup(s => s.BuscaPeloCodigo(It.IsAny<int>())).Returns(_objVenda);

            var _vendaItem = new Mock<IVendaItemAppServico>();
            _vendaItem.Setup(s => s.ListaTodos(It.IsAny<int>())).Returns(new List<VendaItemResponse>());

            var _app = new VendaAppServico(new Mock<IClienteServico>().Object,
                                           new Mock<IFilialServico>().Object,
                                           _servico.Object,
                                           _vendaItem.Object).BuscaPeloCodigo(It.IsAny<int>());

            Assert.True(_app != null);
        }
    }
}
