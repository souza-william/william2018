using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrabalhoFinal.Dominio.Entidades;
using TrabalhoFinal.Testes.Base;
using TrabalhoFinal.Dominio.Excecoes;

namespace TrabalhoFinal.Testes.Dominio_Testes
{
    [TestClass]
    public class ClienteTeste
    {
        private Cliente _cliente;

        [TestInitialize]
        public void Inicializador()
        {
            _cliente = ConstrutorObjeto.CriarCliente();
        }

        [TestMethod]
        public void Cliente_deve_ter_primeiro_nome()
        {
            Assert.AreEqual("William", _cliente.PrimeiroNome);
        }

        [TestMethod]
        public void Cliente_deve_ter_sobrenome()
        {
            Assert.AreEqual("Souza", _cliente.Sobrenome);
        }

        [TestMethod]
        public void Cliente_deve_ter_nome_completo()
        {
            Assert.AreEqual("William Souza", _cliente.NomeCompleto);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_deve_ter_um_primeiro_nome_valido()
        {
            _cliente.PrimeiroNome = "";

            _cliente.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_deve_ter_um_sobrenome_valido()
        {
            var _cliente = ConstrutorObjeto.CriarCliente();

            _cliente.Sobrenome = "";

            _cliente.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_deve_ter_um_telefone_valido()
        {
            var _cliente = ConstrutorObjeto.CriarCliente();

            _cliente.Telefone = "";

            _cliente.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_deve_ter_um_endereco_valido()
        {
            var _cliente = ConstrutorObjeto.CriarCliente();

            _cliente.Endereco = null;

            _cliente.Validar();
        }
    }
}
