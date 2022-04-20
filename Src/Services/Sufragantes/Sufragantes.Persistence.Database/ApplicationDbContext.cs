using Microsoft.EntityFrameworkCore;
using Sufragantes.Domain;
using Sufragantes.Persistence.Database.Configuration;
using System;

namespace Sufragantes.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
          DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Sufragante> tbl_Sufragantes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new SufraganteConfiguration(modelBuilder.Entity<Sufragante>());
        }
    }
}
