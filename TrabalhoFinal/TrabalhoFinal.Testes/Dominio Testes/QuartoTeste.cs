using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrabalhoFinal.Dominio.Entidades;
using TrabalhoFinal.Testes.Base;

namespace TrabalhoFinal.Testes.Dominio_Testes
{
    [TestClass]
    public class QuartoTeste
    {
        private Quarto _quarto;

        [TestInitialize]
        public void Inicializador()
        {
            _quarto = ConstrutorObjeto.CriarQuarto();
        }
    }
}
