using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using Sufragantes.Persistence.Database;
using Sufragantes.Service.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sufragantes.Service.Queries
{
    public interface ISufraganteQueryService
    {
        Task<DataCollection<SufraganteDto>> GetAllAsync(int page, int take, IEnumerable<long> Sufragante = null);

        Task<SufraganteDto> GetAsync(int DocumentType, string identity);
    }
    public class SufraganteQueryService : ISufraganteQueryService
    {
        private readonly ApplicationDbContext _context;

        public SufraganteQueryService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<SufraganteDto>> GetAllAsync(int page, int take, IEnumerable<long> Sufragante = null)
        {
            var collection = await _context.tbl_Sufragantes
                                    .Where(x => Sufragante == null || Sufragante.Contains(x.Id))
                                    .OrderByDescending(x => x.Id)
                                    .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<SufraganteDto>>();
        }  

        public async Task<SufraganteDto> GetAsync(int DocumentType, string identity)
        {
            return (await _context.tbl_Sufragantes.SingleAsync(x => x.Tipo_Identificacion == DocumentType && x.Identificacion == identity)).MapTo<SufraganteDto>();
        }
    }
}
