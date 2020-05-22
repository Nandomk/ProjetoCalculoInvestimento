using CalculoInvestimento.Domain;
using CalculoInvestimento.Domain.Constants;
using CalculoInvestimento.Domain.Interfaces.Repositories;
using CalculoInvestimento.Domain.Interfaces.Services;
using CalculoInvestimento.Domain.Models;
using CalculoInvestimento.Domain.TipoInvestimento;
using CalculoInvestimento.Infra.Mappings;
using CalculoInvestimento.Infra.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculoInvestimento.Application.Services
{
    public class InvestimentosServices : IInvestimentosServices
    {
        ILciRepository _lcis;
        IFundosRepository _fundos;
        ITesouroDiretoRepository _tds;
        IDistributedCache _distributedCache;

        public InvestimentosServices(ILciRepository lcis, 
            IFundosRepository fundos, 
            ITesouroDiretoRepository tds,
            IDistributedCache distributedCache)
        {
            _lcis = lcis;
            _fundos = fundos;
            _tds = tds;
            _distributedCache = distributedCache;
        }
        public async Task<InvestimentosResposta> Get()
        {
            var resp = new InvestimentosResposta();
            var lcis = new LciModel();
            var fundos = new FundoModel();
            var tes = new TesouroDiretoModel();

            var dtLim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            double minExpirate = (dtLim - DateTime.Now).TotalMinutes;

            var opcoesCache = new DistributedCacheEntryOptions();
            opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(minExpirate));

            //lcis = await _lcis.Get();
            //fundos = await _fundos.Get();
            //tes = await _tds.Get();

            var lcCache = this._distributedCache.GetString("lcis");
            var fuCache = this._distributedCache.GetString("fundos");
            var teCache = this._distributedCache.GetString("tes");

            if (lcCache != null)
            {
                lcis = JsonSerializer.Deserialize<LciModel>(lcCache);
            }
            else
            {
                lcis = await _lcis.Get();
                this._distributedCache.SetString("lcis", JsonSerializer.Serialize(lcis), opcoesCache);
            }

            if (fuCache != null)
            {
                fundos = JsonSerializer.Deserialize<FundoModel>(fuCache);
            }
            else
            {
                fundos = await _fundos.Get();
                this._distributedCache.SetString("fundos", JsonSerializer.Serialize(fundos), opcoesCache);
            }

            if (teCache != null)
            {
                tes = JsonSerializer.Deserialize<TesouroDiretoModel>(teCache);
            }
            else
            {
                tes = await _tds.Get();
                this._distributedCache.SetString("tes", JsonSerializer.Serialize(tes), opcoesCache);
            }


            foreach (var l in lcis.lcis)
            {
                resp.investimentos.Add(l.ToModel());
            }
            foreach (var fu in fundos.fundos)
            {
                resp.investimentos.Add(fu.ToModel());
            }
            foreach (var td in tes.tds)
            {
                resp.investimentos.Add(td.ToModel());
            }


            return resp;
        }
    }
}
