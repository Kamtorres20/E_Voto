using Candidatos.Persistence.Database;
using Candidatos.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidatos.Service.Queries
{
    public interface ICandidatoQueryService
    {
        Task<DataCollection<CandidatoDto>> GetAllAsync(int page, int take, IEnumerable<long> Candidato = null);

        Task<CandidatoDto> GetAsync(int DocumentType, string identity);
    }
    public class CandidatoQueryService : ICandidatoQueryService
    {
        private readonly ApplicationDbContext _context;

        public CandidatoQueryService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<CandidatoDto>> GetAllAsync(int page, int take, IEnumerable<long> Candidato = null)
        {
            var collection = await _context.tbl_Candidatos
                                    .Where(x => Candidato == null || Candidato.Contains(x.Id))
                                    .OrderByDescending(x => x.Id)
                                    .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<CandidatoDto>>();
        }

        public async Task<CandidatoDto> GetAsync(int DocumentType, string identity)
        {
            return (await _context.tbl_Candidatos.SingleAsync(x => x.Tipo_Identificacion == DocumentType && x.Identificacion == identity)).MapTo<CandidatoDto>();
        }
    }
}
