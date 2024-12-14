using Moq;
using Taking.Aplicacao.Servico;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Servico;

namespace Taking.Aplicacao.Teste
{
    public class ClienteTeste
    {
        [Fact]
        public void ListaTodos_Ok()
        {
            var _lstClientes = new List<ClienteDominio>()
            {
                new ClienteDominio { Id = 1, NomCliente = "Teste I", IdcSituacao = "A" },
                new ClienteDominio { Id = 2, NomCliente = "Teste II", IdcSituacao = "A" }
            };

            var _servico = new Mock<IClienteServico>();
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstClientes);

            var _app = new ClienteAppServico(_servico.Object).ListaTodos("T");

            Assert.True(_app.Count() != 0);
        }

        [Fact]
        public void ListaTodos_VazioOk()
        {
            var _lstClientes = new List<ClienteDominio>();

            var _servico = new Mock<IClienteServico>();
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstClientes);

            var _app = new ClienteAppServico(_servico.Object).ListaTodos("T");

            Assert.True(_app.Count() == 0);
        }

        [Fact]
        public void BuscaPorId_Ok()
        {
            var _objCliente = new ClienteDominio { Id = 1, NomCliente = "Teste I", IdcSituacao = "A" };

            var _servico = new Mock<IClienteServico>();
            _servico.Setup(s => s.BuscaPorId(It.IsAny<int>())).Returns(_objCliente);

            var _app = new ClienteAppServico(_servico.Object).BuscaPorId(It.IsAny<int>());

            Assert.True(_app != null);
        }

        [Fact]
        public void Add_Ok()
        {
            var _objCliente = new ClienteDominio { Id = 1, NomCliente = "Teste I", IdcSituacao = "A" };

            var _lstClientes = new List<ClienteDominio>()
            {
                new ClienteDominio { Id = 2, NomCliente = "Teste II", IdcSituacao = "A" },
                new ClienteDominio { Id = 3, NomCliente = "Teste III", IdcSituacao = "A" }
            };

            var _servico = new Mock<IClienteServico>();

            _servico.Setup(s => s.Add(_objCliente)).Returns(string.Empty);
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstClientes);

            var _app = new ClienteAppServico(_servico.Object).Add(_objCliente);

            Assert.True(string.IsNullOrEmpty(_app));
        }

        [Fact]
        public void Add_RegistroJaCadastradoOk()
        {
            var _objCliente = new ClienteDominio { Id = 1, NomCliente = "Teste I", IdcSituacao = "A" };

            var _lstClientes = new List<ClienteDominio>()
            {
                new ClienteDominio { Id = 1, NomCliente = "Teste I", IdcSituacao = "A" },
                new ClienteDominio { Id = 2, NomCliente = "Teste II", IdcSituacao = "A" }
            };

            var _servico = new Mock<IClienteServico>();

            _servico.Setup(s => s.Add(_objCliente)).Returns(string.Empty);
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstClientes);

            var _app = new ClienteAppServico(_servico.Object).Add(_objCliente);

            Assert.True(!string.IsNullOrEmpty(_app));
        }

        [Fact]
        public void Update_Ok()
        {
            var _objCliente = new ClienteDominio { Id = 1, NomCliente = "Teste I", IdcSituacao = "A" };

            var _lstClientes = new List<ClienteDominio>()
            {
                new ClienteDominio { Id = 2, NomCliente = "Teste II", IdcSituacao = "A" },
                new ClienteDominio { Id = 3, NomCliente = "Teste III", IdcSituacao = "A" }
            };

            var _servico = new Mock<IClienteServico>();

            _servico.Setup(s => s.Add(_objCliente)).Returns(string.Empty);
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstClientes);

            var _app = new ClienteAppServico(_servico.Object).Update(_objCliente);

            Assert.True(string.IsNullOrEmpty(_app));
        }

        [Fact]
        public void Update_RegistroJaCadastradoOk()
        {
            var _objCliente = new ClienteDominio { Id = 2, NomCliente = "Teste I", IdcSituacao = "A" };

            var _lstClientes = new List<ClienteDominio>()
            {
                new ClienteDominio { Id = 1, NomCliente = "Teste I", IdcSituacao = "A" }
            };

            var _servico = new Mock<IClienteServico>();

            _servico.Setup(s => s.Add(_objCliente)).Returns(string.Empty);
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstClientes);

            var _app = new ClienteAppServico(_servico.Object).Update(_objCliente);

            Assert.True(!string.IsNullOrEmpty(_app));
        }

        [Fact]
        public void Excliu_Ok()
        {
            var _servico = new Mock<IClienteServico>();

            _servico.Setup(s => s.Remove(It.IsAny<int>())).Returns(string.Empty);

            var _app = new ClienteAppServico(_servico.Object).Remove(It.IsAny<int>());

            Assert.True(string.IsNullOrEmpty(_app));
        }
    }
}
