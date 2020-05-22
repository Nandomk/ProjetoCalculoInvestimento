using CalculoInvestimento.Domain.Constants;
using CalculoInvestimento.Domain.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CalculoInvestimento.Domain.Interfaces.Repositories;

namespace CalculoInvestimento.Infra.Repositories
{
    public class TesouroDiretoRepository : ITesouroDiretoRepository
    {
        public TesouroDiretoRepository()
        {

        }
        public virtual async Task<TesouroDiretoModel> Get()
        {
            var client = new HttpClient();
            var prodResp = await client.GetAsync(EndPointInvestimentos.TesouroDireto);
            var jsonString = await prodResp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TesouroDiretoModel>(jsonString);
        }
    }
}
