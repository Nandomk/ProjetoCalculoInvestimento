using CalculoInvestimento.Domain.TipoInvestimento;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculoInvestimento.Tests
{
    [TestClass]
    public class TesteCalculosImpostos
    {
        [TestMethod]
        public void CalculoImpostoLci()
        {
            Lci l = new Lci();
            l.capitalInvestido = 2000M;
            l.capitalAtual = 2097.85M;            
            Assert.AreEqual(l.imposto, 4.8925M);
        }

        [TestMethod]
        public void CalculoImpostoTesouroDireto()
        {
            TesouroDireto t = new TesouroDireto();
            t.valorInvestido = 799.472M;
            t.valorTotal = 829.68M;
            Assert.AreEqual(t.imposto, 3.0208M);
        }

        [TestMethod]
        public void CalculoImpostoFundos()
        { 
            Fundo f = new Fundo();
            f.capitalInvestido = 10000M;
            f.ValorAtual = 12300.52M;
            Assert.AreEqual(f.imposto, 345.078M);
        }
    }
}
