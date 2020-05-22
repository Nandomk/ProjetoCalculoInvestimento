using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoInvestimento.Domain.Constants
{
    public static class TaxaIR
    {
        public static decimal TesouroDireto { get { return 0.10M; } }

        public static decimal Lcis { get { return 0.05M; } }

        public static decimal Fundos { get { return 0.15M; } }
    }
}
