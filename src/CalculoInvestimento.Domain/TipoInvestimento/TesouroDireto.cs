using CalculoInvestimento.Domain.Constants;
using System;

namespace CalculoInvestimento.Domain.TipoInvestimento
{
    public class TesouroDireto : TipoBase
    {
        public decimal valorInvestido { get; set; }
        public decimal valorTotal { get; set; }
        public DateTime vencimento { get; set; }
        public DateTime dataDeCompra { get; set; }
        public int iof { get; set; }
        public string indice { get; set; }
        public string tipo { get; set; }
        public string nome { get; set; }       

        public decimal imposto 
        {
            get
            {
                return CalculaImposto(valorInvestido, valorTotal);
            }
        }
        public decimal valorResgate
        {
            get
            {
                return CalculoResgate(valorTotal, dataDeCompra, vencimento);
            }
        }
        public TesouroDireto()
        {
            _taxaIR = TaxaIR.TesouroDireto;
        }
        

    }
}
