using Infectados.Domain.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infectados.Data.Servicos
{
    public interface IInfectadoRepository
    {
        Task<Infectado> ObterInfectadoPorIdAsync(string id);
        Task<IEnumerable<Infectado>> ObterTodosInfectadosAsync();
        Task SalvarInfectadoAsync(Infectado infectado);
    }
}