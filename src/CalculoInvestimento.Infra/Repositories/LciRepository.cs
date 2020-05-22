using CalculoInvestimento.Domain.Constants;
using CalculoInvestimento.Domain.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CalculoInvestimento.Domain.Interfaces.Repositories;

namespace CalculoInvestimento.Infra.Repositories
{
    public class LciRepository :ILciRepository
    {
        public LciRepository()
        {


        }
        public virtual async Task<LciModel> Get()
        {
            var client = new HttpClient();
            var prodResp = await client.GetAsync(EndPointInvestimentos.Lcis);
            var jsonString = await prodResp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LciModel>(jsonString);
        }
    }
}
