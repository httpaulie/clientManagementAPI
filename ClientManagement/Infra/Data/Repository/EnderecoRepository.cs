using Domain.Models;
using Infra.Data.Context;
using Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ClientDbContext _context;
        public EnderecoRepository(ClientDbContext context)
        {
            _context = context;
        }

        public async Task<Endereco> GetByIdAsync(long id)
        {
            return await _context.Enderecos
                .Include(x => x.ClientesPessoasFisicas)
                .Include(x => x.ClientesPessoasJuridicas)
                .Where(a => a.Id == id).FirstOrDefaultAsync();
        }

    }
}
