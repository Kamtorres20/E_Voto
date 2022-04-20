using Elecciones.Domain;
using Elecciones.Persistence.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace Elecciones.Persistence.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Eleccion> Tbl_Elecciones { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new EleccionConfiguration(modelBuilder.Entity<Eleccion>());
        }

    }
}
