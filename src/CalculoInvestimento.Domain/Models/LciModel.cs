using CalculoInvestimento.Domain.TipoInvestimento;
using System.Collections.Generic;

namespace CalculoInvestimento.Domain.Models
{
    public class LciModel
    {
        public IList<Lci> lcis { get; set; }
        public LciModel()
        {
            lcis = new List<Lci>();
        }
    }
}
