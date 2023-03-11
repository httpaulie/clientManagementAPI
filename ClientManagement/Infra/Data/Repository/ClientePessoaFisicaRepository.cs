using Domain.Models;
using Infra.Data.Context;
using Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class ClientePessoaFisicaRepository : IClientePessoaFisicaRepository
    {
        protected readonly ClientDbContext _context;

        public ClientePessoaFisicaRepository(ClientDbContext context)
        {
            _context = context;
        }

        public async Task<ClientePessoaFisica> GetByIdAsync(long id)
        {
            return await _context.ClientesPessoasFisicas.Include(x => x.Endereco).Where(a => a.Id == id).FirstOrDefaultAsync();
        }
    }
}
