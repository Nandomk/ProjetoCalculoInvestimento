using CalculoInvestimento.Domain.Models;
using CalculoInvestimento.Domain.TipoInvestimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoInvestimento.Infra.Mappings
{
    public static class InvestimentoMapping
    {
        public static List<Investimento> ToModels(this LciModel model)
        {
            return model.lcis.Select(item => item.ToModel()).ToList();
        }
        public static List<Investimento> ToModels(this TesouroDiretoModel model)
        {
            return model.tds.Select(item => item.ToModel()).ToList();
        }
        public static List<Investimento> ToModels(this FundoModel model)
        {
            return model.fundos.Select(item => item.ToModel()).ToList();
        }

        public static Investimento ToModel(this Lci m)
        {
            return new Investimento()
            {
                nome = m.nome,
                valorInvestido = m.capitalInvestido,
                valorTotal = m.capitalAtual,
                vencimento = m.vencimento,
                Ir = m.imposto,
                valorResgate = m.valorResgate,
            };
        }
        public static Investimento ToModel(this TesouroDireto m)
        {
            return new Investimento()
            {
                nome = m.nome,
                valorInvestido = m.valorInvestido,
                valorTotal = m.valorTotal,
                vencimento = m.vencimento,
                Ir = m.imposto,
                valorResgate = m.valorResgate,
            };
        }
        public static Investimento ToModel(this Fundo m)
        {
            return new Investimento()
            {
                nome = m.nome,
                valorInvestido = m.capitalInvestido,
                valorTotal = m.ValorAtual,
                vencimento = null,
                Ir = m.imposto,
                valorResgate = m.valorResgate,
            };
        }


    }
}
