using CalculoInvestimento.Domain.TipoInvestimento;
using System.Collections.Generic;

namespace CalculoInvestimento.Domain.Models
{
    public class FundoModel
    {
        public IList<Fundo>  fundos{get;set;}

        public FundoModel()
        {

        }
    }
}
