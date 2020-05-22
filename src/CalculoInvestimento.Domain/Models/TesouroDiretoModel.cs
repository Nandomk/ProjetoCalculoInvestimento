using CalculoInvestimento.Domain.TipoInvestimento;
using System.Collections.Generic;

namespace CalculoInvestimento.Domain.Models
{
    public class TesouroDiretoModel
    {
        public IList<TesouroDireto> tds { get; set; }
        public TesouroDiretoModel()
        {
            tds = new List<TesouroDireto>();
        }
    }
}
