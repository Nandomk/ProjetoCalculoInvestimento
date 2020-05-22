using CalculoInvestimento.Domain.TipoInvestimento;
using CalculoInvestimento.Infra.Repositories;
using System;
using System.Text.Json;

namespace CalculoInvestimento.ConsoleApp
{
    class Program
    {
        static  void Main(string[] args)
        {
            Lci l = new Lci();
            l.capitalInvestido = 2000M;
            l.capitalAtual = 2097.85M;
            var res = l.imposto;
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
