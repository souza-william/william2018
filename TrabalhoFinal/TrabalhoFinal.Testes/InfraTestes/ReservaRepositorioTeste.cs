using System;
using System.Collections.Generic;
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
    public class ReservaRepositorioTeste
    {
        private HotelContexto _contextoTeste;
        private ReservaRepositorio _repositorio;
        private QuartoRepositorio _repositorioQuarto;
        private Reserva _reservaTest;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<HotelContexto>());

            _contextoTeste = new HotelContexto();

            _repositorio = new ReservaRepositorio();
            _repositorioQuarto = new QuartoRepositorio();

            _reservaTest = ConstrutorObjeto.CriarReserva();

            _contextoTeste.Database.Initialize(true);
        }

        [TestMethod]
        public void Deveria_adicionar_uma_nova_reserva()
        {
            //Preparação
            var quarto1 = _repositorioQuarto.BuscarPor(1);

            _reservaTest.Quartos = new List<Quarto>();
            _reservaTest.Adiciona(quarto1);

            _reservaTest.CalculaTotal();

            //Ação
            _repositorio.Adicionar(_reservaTest);

            //Afirmar
            var todasReservas = _contextoTeste.Reservas.ToList();

            Assert.AreEqual(2, todasReservas.Count);
        }

        [TestMethod]
        public void Deveria_editar_uma_reserva()
        {
            //Preparação
            var reservaEditada = _repositorio.BuscarPor(1);

            reservaEditada.DataReserva = new DateTime(2018, 02, 19);

            //Ação
            _repositorio.Editar(reservaEditada);

            //Afirmar
            var reservaBuscada = _contextoTeste.Reservas.Find(1);

            Assert.AreEqual(new DateTime(2018, 02, 19), reservaBuscada.DataReserva);
        }

        [TestMethod]
        public void Deveria_deletar_uma_reserva()
        {
            //Preparação
            var reservaDeletada = _repositorio.BuscarPor(1);

            //Ação
            _repositorio.Deletar(reservaDeletada);

            //Afirmar
            var todasReservas = _contextoTeste.Reservas.ToList();

            Assert.AreEqual(0, todasReservas.Count);
        }

        [TestMethod]
        public void Deveria_buscar_reserva_por_id()
        {

            //Preparação

            //Ação
            var reservaBuscada = _repositorio.BuscarPor(1);

            //Afirmar

            Assert.IsNotNull(reservaBuscada);
        }

        [TestMethod]
        public void Deveria_buscar_todos_as_reservas()
        {
            //Preparação

            //Ação
            var reservaBuscada = _repositorio.BuscarTudo();

            //Afirmar

            Assert.IsNotNull(reservaBuscada);
        }
    }
}
