using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sufragantes.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufragantes.Persistence.Database.Configuration
{
    public class SufraganteConfiguration
    {
        public SufraganteConfiguration(EntityTypeBuilder<Sufragante> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
