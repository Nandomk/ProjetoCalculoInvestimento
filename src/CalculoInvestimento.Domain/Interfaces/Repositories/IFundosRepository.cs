using CalculoInvestimento.Domain.Models;
using System.Threading.Tasks;

namespace CalculoInvestimento.Domain.Interfaces.Repositories
{
    public interface IFundosRepository
    {
        Task<FundoModel> Get();
    }
}
