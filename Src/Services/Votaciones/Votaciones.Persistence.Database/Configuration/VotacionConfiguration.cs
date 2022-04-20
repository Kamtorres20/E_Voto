
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Votaciones.Domain;

namespace Votaciones.Persistence.Database.Configuration
{
    public class VotacionConfiguration
    {
        public VotacionConfiguration(EntityTypeBuilder<Votacion> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
