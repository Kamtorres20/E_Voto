using Candidatos.Domain;
using Candidatos.Persistence.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace Candidatos.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
         DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Candidato> tbl_Candidatos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new CandidatoConfiguration(modelBuilder.Entity<Candidato>());
        }
    }
}
