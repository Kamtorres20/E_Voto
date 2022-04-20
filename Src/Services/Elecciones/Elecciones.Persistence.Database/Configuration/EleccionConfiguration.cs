using Elecciones.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elecciones.Persistence.Database.Configuration
{
    public class EleccionConfiguration
    {
        public EleccionConfiguration(EntityTypeBuilder<Eleccion> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
