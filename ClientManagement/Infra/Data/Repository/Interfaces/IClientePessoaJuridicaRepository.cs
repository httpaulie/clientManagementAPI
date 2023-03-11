using Domain.Models;

namespace Infra.Data.Repository.Interfaces
{
    public interface IClientePessoaJuridicaRepository
    {
        Task<ClientePessoaJuridica> GetByIdAsync(long id);
    }
}
