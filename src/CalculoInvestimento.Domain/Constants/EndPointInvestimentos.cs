using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoInvestimento.Domain.Constants
{
    public static class EndPointInvestimentos
    {
        public static string Fundos
        {
            get { return $"http://www.mocky.io/v2/5e342ab33000008c00d96342"; }
        }
        public static string Lcis
        {
            get { return $"http://www.mocky.io/v2/5e3429a33000008c00d96336"; }
        }
        public static string TesouroDireto
        {
            get { return $"http://www.mocky.io/v2/5e3428203000006b00d9632a"; }
        }
    }
}
