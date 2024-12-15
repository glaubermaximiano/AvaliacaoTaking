using Moq;
using System.Diagnostics.CodeAnalysis;
using Taking.Aplicacao.Servico;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Servico;
using Taking.Dominio.Request;
using Taking.Dominio.Response;
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
                NumFilial = 1,
                NumCliente = 1
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
                NumFilial = 1,
                NumCliente = 0
            };

            var _msg = ValidaPreenchimento.Validar(_obj);

            Assert.True(!string.IsNullOrEmpty(_msg));
        }

        [Fact]
        public void ListaPorDatas_Ok()
        {
            var _lstVendas = new List<VendaDominio>()
            {
               new VendaDominio(){  
                                    Id = It.IsAny<int>(),
                                    CodVenda = It.IsAny<string>(),
                                    DthVenda = It.IsAny<DateTime>(),
                                    IdcSituacao = It.IsAny<string>(),
                                    NumCliente = It.IsAny<int>(),
                                    NumFilial = It.IsAny<int>()
                                 }
            };

            var _servico = new Mock<IVendaServico>();
            _servico.Setup(s => s.BuscaPorData( It.IsAny<DateTime>(), It.IsAny<DateTime>() )).Returns(_lstVendas);

            var _cliente = new Mock<IClienteServico>();
            _cliente.Setup(s => s.BuscaPorId(It.IsAny<int>())).Returns(It.IsAny<ClienteDominio>());

            var _filial = new Mock<IFilialServico>();
            _filial.Setup(s => s.BuscaPorId(It.IsAny<int>())).Returns(It.IsAny<FilialDominio>());

            var _app = new VendaAppServico(_cliente.Object,
                                           _filial.Object,
                                           _servico.Object).BuscaPorData(It.IsAny<DateTime>(), It.IsAny<DateTime>());

            Assert.True(_app.Count() != 0);
        }

        [Fact]
        public void BuscaPeloCodigo_Ok()
        {
            var _objVenda = new VendaDominio()
            {
                Id = It.IsAny<int>(),
                CodVenda = It.IsAny<string>(),
                DthVenda = It.IsAny<DateTime>(),
                IdcSituacao = It.IsAny<string>(),
                NumCliente = It.IsAny<int>(),
                NumFilial = It.IsAny<int>()
            };

            var _servico = new Mock<IVendaServico>();
            _servico.Setup(s => s.BuscaPeloCodigo(It.IsAny<string>())).Returns(_objVenda);

            var _cliente = new Mock<IClienteServico>();
            _cliente.Setup(s => s.BuscaPorId(It.IsAny<int>())).Returns(It.IsAny<ClienteDominio>());

            var _filial = new Mock<IFilialServico>();
            _filial.Setup(s => s.BuscaPorId(It.IsAny<int>())).Returns(It.IsAny<FilialDominio>());

            var _app = new VendaAppServico(_cliente.Object,
                                           _filial.Object,
                                           _servico.Object).BuscaPeloCodigo(It.IsAny<string>());

            Assert.True(_app != null);
        }
    }
}
