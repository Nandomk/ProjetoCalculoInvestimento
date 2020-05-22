using CalculoInvestimento.Domain.Constants;
using CalculoInvestimento.Domain.Interfaces.Repositories;
using CalculoInvestimento.Domain.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculoInvestimento.Infra.Repositories
{
    public class FundosRepository :IFundosRepository
    {
        public FundosRepository()
        {

        }
        public virtual async Task<FundoModel> Get()
        {
            var client = new HttpClient();
            var prodResp = await client.GetAsync(EndPointInvestimentos.Fundos);
            var jsonString = await prodResp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<FundoModel>(jsonString);
        }
    }
}
