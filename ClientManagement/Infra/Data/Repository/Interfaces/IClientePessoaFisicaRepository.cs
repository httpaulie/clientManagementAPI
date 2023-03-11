using Domain.Models;

namespace Infra.Data.Repository.Interfaces
{
    public interface IClientePessoaFisicaRepository
    {
        Task<ClientePessoaFisica> GetByIdAsync(long id);
    }
}
