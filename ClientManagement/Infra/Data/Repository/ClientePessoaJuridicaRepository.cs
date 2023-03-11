using Domain.Models;
using Infra.Data.Context;
using Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class ClientePessoaJuridicaRepository : IClientePessoaJuridicaRepository
    {
        protected readonly ClientDbContext _context;

        public ClientePessoaJuridicaRepository(ClientDbContext context)
        {
            _context = context;
        }

        public async Task<ClientePessoaJuridica> GetByIdAsync(long id)
        {
            return await _context.ClientesPessoasJuridicas.Include(x => x.Endereco).Where(a => a.Id == id).FirstOrDefaultAsync();
        }
    }
}
