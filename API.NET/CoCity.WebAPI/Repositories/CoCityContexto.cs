using CoCity.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoCity.WebAPI.Repositories
{
    public class CoCityContexto : DbContext
    {
        public CoCityContexto(DbContextOptions<CoCityContexto> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<ReclamacaoModel> Reclamacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>()
                .Property(c => c.Id)
                .ForOracleUseSequenceHiLo("SQ_T_DSR_USUARIO");

            modelBuilder.Entity<EnderecoModel>()
                .Property(c => c.Id)
                .ForOracleUseSequenceHiLo("SQ_T_DSR_ENDERECO");

            modelBuilder.Entity<ReclamacaoModel>()
                .Property(c => c.Id)
                .ForOracleUseSequenceHiLo("SQ_T_DSR_RECLAMACAO");
        }
    }
}
