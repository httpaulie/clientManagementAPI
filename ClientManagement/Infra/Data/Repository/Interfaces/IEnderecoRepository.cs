using Domain.Models;

namespace Infra.Data.Repository.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> GetByIdAsync(long id);
    }
}
