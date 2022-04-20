using Candidatos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidatos.Persistence.Database.Configuration
{
    public class CandidatoConfiguration
    {
        public CandidatoConfiguration(EntityTypeBuilder<Candidato> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}
