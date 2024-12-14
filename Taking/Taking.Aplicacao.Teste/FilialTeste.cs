﻿
using Moq;
using Taking.Aplicacao.Servico;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Servico;

namespace Taking.Aplicacao.Teste
{
    public class FilialTeste
    {
        [Fact]
        public void ListaTodos_Ok()
        {
            var _lstFiliais = new List<FilialDominio>()
            {
                new FilialDominio { Id = 1, NomFilial = "Filial I", IdcSituacao = "A" },
                new FilialDominio { Id = 2, NomFilial = "Filial II", IdcSituacao = "A" }
            };

            var _servico = new Mock<IFilialServico>();
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstFiliais);

            var _app = new FilialAppServico(_servico.Object).ListaTodos("T");

            Assert.True(_app.Count() != 0);
        }

        [Fact]
        public void ListaTodos_VazioOk()
        {
            var _lstFiliais = new List<FilialDominio>();

            var _servico = new Mock<IFilialServico>();
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstFiliais);

            var _app = new FilialAppServico(_servico.Object).ListaTodos("T");

            Assert.True(_app.Count() == 0);
        }

        [Fact]
        public void BuscaPorId_Ok()
        {
            var _objFilial = new FilialDominio { Id = 1, NomFilial = "Filial I", IdcSituacao = "A" };

            var _servico = new Mock<IFilialServico>();
            _servico.Setup(s => s.BuscaPorId(It.IsAny<int>())).Returns(_objFilial);

            var _app = new FilialAppServico(_servico.Object).BuscaPorId(It.IsAny<int>());

            Assert.True(_app != null);
        }

        [Fact]
        public void Add_Ok()
        {
            var _objFilial = new FilialDominio { Id = 1, NomFilial = "Filial I", IdcSituacao = "A" };

            var _lstFilial = new List<FilialDominio>()
            {
                new FilialDominio { Id = 2, NomFilial = "Filial II", IdcSituacao = "A" },
                new FilialDominio { Id = 3, NomFilial = "Filial III", IdcSituacao = "A" }
            };

            var _servico = new Mock<IFilialServico>();

            _servico.Setup(s => s.Add(_objFilial)).Returns(string.Empty);
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstFilial);

            var _app = new FilialAppServico(_servico.Object).Add(_objFilial);

            Assert.True(string.IsNullOrEmpty(_app));
        }

        [Fact]
        public void Add_RegistroJaCadastradoOk()
        {
            var _objFilial = new FilialDominio { Id = 1, NomFilial = "Filial I", IdcSituacao = "A" };

            var _lstFilial = new List<FilialDominio>()
            {
                new FilialDominio { Id = 1, NomFilial = "Filial I", IdcSituacao = "A" },
                new FilialDominio { Id = 2, NomFilial = "Filial II", IdcSituacao = "A" }
            };

            var _servico = new Mock<IFilialServico>();

            _servico.Setup(s => s.Add(_objFilial)).Returns(string.Empty);
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstFilial);

            var _app = new FilialAppServico(_servico.Object).Add(_objFilial);

            Assert.True(!string.IsNullOrEmpty(_app));
        }

        [Fact]
        public void Update_Ok()
        {
            var _objFilial = new FilialDominio { Id = 1, NomFilial = "Filial I", IdcSituacao = "A" };

            var _lstFilial = new List<FilialDominio>()
            {
                new FilialDominio { Id = 2, NomFilial = "Filial II", IdcSituacao = "A" },
                new FilialDominio { Id = 3, NomFilial = "Filial III", IdcSituacao = "A" }
            };

            var _servico = new Mock<IFilialServico>();

            _servico.Setup(s => s.Add(_objFilial)).Returns(string.Empty);
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstFilial);

            var _app = new FilialAppServico(_servico.Object).Update(_objFilial);

            Assert.True(string.IsNullOrEmpty(_app));
        }

        [Fact]
        public void Update_RegistroJaCadastradoOk()
        {
            var _objFilial = new FilialDominio { Id = 2, NomFilial = "Filial I", IdcSituacao = "A" };

            var _lstFilial = new List<FilialDominio>()
            {
                new FilialDominio { Id = 1, NomFilial = "Filial I", IdcSituacao = "A" }
            };

            var _servico = new Mock<IFilialServico>();

            _servico.Setup(s => s.Add(_objFilial)).Returns(string.Empty);
            _servico.Setup(s => s.ListaTodos("T")).Returns(_lstFilial);

            var _app = new FilialAppServico(_servico.Object).Update(_objFilial);

            Assert.True(!string.IsNullOrEmpty(_app));
        }

        [Fact]
        public void Excliu_Ok()
        {
            var _servico = new Mock<IFilialServico>();

            _servico.Setup(s => s.Remove(It.IsAny<int>())).Returns(string.Empty);

            var _app = new FilialAppServico(_servico.Object).Remove(It.IsAny<int>());

            Assert.True(string.IsNullOrEmpty(_app));
        }
    }
}