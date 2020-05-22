using CalculoInvestimento.Domain.Constants;
using System;

namespace CalculoInvestimento.Domain.TipoInvestimento
{
    public class Fundo: TipoBase
    {
        public decimal capitalInvestido { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime dataResgate { get; set; }
        public DateTime dataCompra { get; set; }
        public decimal iof { get; set; }
        public string nome { get; set; }
        public decimal totalTaxas { get; set; }
        public int quantity { get; set; }

        public decimal imposto
        {
            get
            {
                return CalculaImposto(this.capitalInvestido, this.ValorAtual);
            }
        }

        public decimal valorResgate
        {
            get
            {
                return CalculoResgate(ValorAtual, dataCompra, null);
            }
        }

        public Fundo()
        {
            _taxaIR = TaxaIR.Fundos;
        }
        
    }
}
