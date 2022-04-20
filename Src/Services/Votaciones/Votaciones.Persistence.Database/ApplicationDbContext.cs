using Microsoft.EntityFrameworkCore;
using Votaciones.Domain;
using Votaciones.Persistence.Database.Configuration;

namespace Votaciones.Persistence.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Votacion> Tbl_Votacion { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new VotacionConfiguration(modelBuilder.Entity<Votacion>());
        }

    }
}
