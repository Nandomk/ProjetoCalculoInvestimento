using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoInvestimento.Domain.TipoInvestimento
{
    public class TipoBase
    {
        protected decimal _taxaIR;        

        protected decimal CalculaImposto(decimal valorInvestido, decimal valorTotal)
        {
            return (valorTotal - valorInvestido) * _taxaIR;
        }
        protected decimal CalculoResgate(decimal valorTotal, DateTime dataCompra, DateTime? dataVencimento)
        {
            if (!dataVencimento.HasValue)
                return valorTotal - (valorTotal * 0.30M);

            var tempoMinimoParaVencimentoEmDias = 90;
            var hj = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            var metadeTempoTotalCustodiaEmDias = ((dataVencimento.Value - dataCompra).TotalDays / 2);
            var tempoRegateDias = (dataVencimento.Value - hj).TotalDays;
            var tempoCustodiaEmDias = (hj - dataCompra).TotalDays;

            if (tempoCustodiaEmDias > metadeTempoTotalCustodiaEmDias && tempoRegateDias < tempoMinimoParaVencimentoEmDias)
            {
                return valorTotal - (valorTotal * 0.06M);
            }
            else if (tempoRegateDias > metadeTempoTotalCustodiaEmDias)
            {
                return valorTotal - (valorTotal * 0.15M);
            }
            else
            {
                return valorTotal - (valorTotal * 0.30M);
            }
        }

    }
}
