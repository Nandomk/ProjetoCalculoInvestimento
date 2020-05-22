using CalculoInvestimento.Domain.TipoInvestimento;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculoInvestimento.Tests
{
    [TestClass]
    public class TesteCalculoResgate
    {
        [TestMethod]
        public void CalculoResgateLci()
        {
            Lci l = new Lci();
            l.capitalAtual = 2097.85M;
            l.dataOperacao = new DateTime(2019, 03, 14, 0, 0, 0);
            l.vencimento = new DateTime(2021, 03, 09, 0, 0, 0);
            Assert.AreEqual(l.valorResgate, 1468.495M);
        }

        [TestMethod]
        public void CalculoResgateTesouro()
        {
            TesouroDireto l = new TesouroDireto();
            l.valorTotal = 502.787M;
            l.dataDeCompra = new DateTime(2010, 02, 10, 0, 0, 0);
            l.vencimento = new DateTime(2020, 02, 01, 0, 0, 0);
            Assert.AreEqual(l.valorResgate, 472.61978M);
        }

        [TestMethod]
        public void CalculoResgateFundo()
        {
            Fundo l = new Fundo();
            l.ValorAtual = 1159M;
            l.dataCompra = new DateTime(2017, 10, 01, 0, 0, 0);
            
            Assert.AreEqual(l.valorResgate, 811.3M);
        }

        [TestMethod]
        public void CalculoResgateFundo2()
        {
            Fundo l = new Fundo();
            l.ValorAtual = 12300.52M;
            l.dataCompra = new DateTime(2019, 11, 15, 0, 0, 0);

            Assert.AreEqual(l.valorResgate, 10455.442M);
        }
    }
}
