using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrabalhoFinal.Infra.Dados.Contexto;
using TrabalhoFinal.Infra.Dados.Repositorios;
using TrabalhoFinal.Dominio.Entidades;
using System.Data.Entity;
using TrabalhoFinal.Testes.Base;
using System.Linq;

namespace TrabalhoFinal.Testes.InfraTestes
{
    [TestClass]
    public class QuartoRepositorioTeste
    {
        private HotelContexto _contextoTeste;
        private QuartoRepositorio _repositorio;
        private Quarto _quartoTest;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<HotelContexto>());

            _contextoTeste = new HotelContexto();

            _repositorio = new QuartoRepositorio();

            _quartoTest = ConstrutorObjeto.CriarQuarto();

            _contextoTeste.Database.Initialize(true);
        }

        [TestMethod]
        public void Deveria_adicionar_um_novo_quarto()
        {
            //Preparação

            //Ação
            _repositorio.Adicionar(_quartoTest);

            //Afirmar
            var todosQuartos = _contextoTeste.Quartos.ToList();

            Assert.AreEqual(3, todosQuartos.Count);
        }

        [TestMethod]
        public void Deveria_editar_um_quarto()
        {
            //Preparação
            var quartoEditado = _contextoTeste.Quartos.Find(1);
            quartoEditado.Nome = "EDITADO";

            //Ação
            _repositorio.Editar(quartoEditado);

            //Afirmar
            var quartoBuscado = _contextoTeste.Quartos.Find(1);

            Assert.AreEqual("EDITADO", quartoBuscado.Nome);
        }

        [TestMethod]
        public void Deveria_deletar_um_quarto()
        {
            //Preparação
            var quartoDeletado = _contextoTeste.Quartos.Find(1);

            //Ação
            _repositorio.Deletar(quartoDeletado);

            //Afirmar
            var todosQuartos = _contextoTeste.Quartos.ToList();

            Assert.AreEqual(1, todosQuartos.Count);
        }

        [TestMethod]
        public void Deveria_buscar_quarto_por_id()
        {

            //Preparação

            //Ação
            var quartoBuscado = _repositorio.BuscarPor(1);

            //Afirmar

            Assert.IsNotNull(quartoBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_quartos()
        {
            //Preparação

            //Ação
            var quartoBuscado = _repositorio.BuscarTudo();

            //Afirmar

            Assert.IsNotNull(quartoBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_quarto_por_nome()
        {
            //Preparação

            //Ação
            var quartoBuscado = _repositorio.BuscarPorNome("Solteiro");

            //Afirmar

            Assert.IsNotNull(quartoBuscado);
        }
    }
}
