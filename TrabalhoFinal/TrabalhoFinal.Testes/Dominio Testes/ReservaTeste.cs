using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrabalhoFinal.Dominio.Entidades;
using TrabalhoFinal.Testes.Base;

namespace TrabalhoFinal.Testes.Dominio_Testes
{
    [TestClass]
    public class ReservaTeste
    {
        private Reserva _reserva;

        [TestInitialize]
        public void Inicializador()
        {
            _reserva = ConstrutorObjeto.CriarReserva();
        }
    }
}
