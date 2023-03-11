using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Context
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }

        public DbSet<ClientePessoaFisica> ClientesPessoasFisicas { get; set; }
        public DbSet<ClientePessoaJuridica> ClientesPessoasJuridicas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientePessoaFisica>(entity => entity.HasKey(e => new { e.Id }));
            modelBuilder.Entity<ClientePessoaFisica>()
                .HasOne(a => a.Endereco)
                .WithMany(t => t.ClientesPessoasFisicas)
                .HasForeignKey(a => a.EnderecoId);

            modelBuilder.Entity<ClientePessoaJuridica>(entity => entity.HasKey(e => new { e.Id }));
            modelBuilder.Entity<ClientePessoaJuridica>()
                .HasOne(a => a.Endereco)
                .WithMany(t => t.ClientesPessoasJuridicas)
                .HasForeignKey(a => a.EnderecoId);

            modelBuilder.Entity<Endereco>(entity => entity.HasKey(e => new { e.Id }));
            modelBuilder.Entity<Endereco>()
                .HasMany(t => t.ClientesPessoasFisicas);
            modelBuilder.Entity<Endereco>()
                .HasMany(t => t.ClientesPessoasJuridicas);

        }
    }
}
