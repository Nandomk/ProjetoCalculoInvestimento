using CalculoInvestimento.Domain.Constants;
using System;
using System.Collections.Generic;

namespace CalculoInvestimento.Domain.TipoInvestimento
{
    public class Lci : TipoBase
    {
        public decimal capitalInvestido { get; set; }
        public decimal capitalAtual { get; set; }
        public decimal quantidade { get; set; }
        public DateTime vencimento { get; set; }
        public decimal iof { get; set; }
        public decimal outrasTaxas { get; set; }
        public decimal taxas { get; set; }
        public string indice { get; set; }
        public string tipo { get; set; }
        public string nome { get; set; }
        public bool guarantidoFGC { get; set; }
        public DateTime dataOperacao { get; set; }
        public decimal precoUnitario { get; set; }
        public bool primario { get; set; }

        public decimal imposto
        {
            get
            {
                return CalculaImposto(this.capitalInvestido, this.capitalAtual);
            }
        }
        public decimal valorResgate
        {
            get
            {
                return CalculoResgate(capitalAtual, dataOperacao, vencimento);
            }
        }
        public Lci()
        {
            _taxaIR = TaxaIR.Lcis;
        }
    }
}
