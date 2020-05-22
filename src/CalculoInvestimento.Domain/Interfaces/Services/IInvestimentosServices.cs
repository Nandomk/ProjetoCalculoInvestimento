using CalculoInvestimento.Domain.Models;
using System.Threading.Tasks;

namespace CalculoInvestimento.Domain.Interfaces.Services
{
    public interface IInvestimentosServices
    {
        Task<InvestimentosResposta> Get();
    }
}
