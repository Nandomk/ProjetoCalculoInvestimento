using System.Collections.Generic;
using System.Linq;

namespace CalculoInvestimento.Domain.Models
{
    public class InvestimentosResposta
    {
        public decimal valorTotal  { get { return CalculaTotal(); }  }
        public IList<Investimento> investimentos { get; set; }

        public InvestimentosResposta()
        {
            investimentos = new List<Investimento>();
        }

        private decimal CalculaTotal()
        {
            return investimentos.Count > 0 ? investimentos.Sum(e => e.valorInvestido) :0;
        }
    }
}
