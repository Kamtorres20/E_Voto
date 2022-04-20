using Elecciones.Persistence.Database;
using Elecciones.Service.Query.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elecciones.Service.Query
{
    public interface IEleccionQueryService
        {
            Task<DataCollection<EleccionDto>> GetAllAsync(int page, int take, IEnumerable<long> Eleccion = null);

            Task<EleccionDto> GetAsync(int IdEleccion);
        }
    public class EleccionQueryService : IEleccionQueryService
        {
            private readonly ApplicationDbContext _context;

            public EleccionQueryService(
                ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<DataCollection<EleccionDto>> GetAllAsync(int page, int take, IEnumerable<long> Eleccion = null)
            {
                var collection = await _context.Tbl_Elecciones
                                        .Where(x => Eleccion == null || Eleccion.Contains(x.Id))
                                        .OrderByDescending(x => x.Id)
                                        .GetPagedAsync(page, take);

                return collection.MapTo<DataCollection<EleccionDto>>();
            }

            public async Task<EleccionDto> GetAsync(int IdEleccion)
            {
                return (await _context.Tbl_Elecciones.SingleAsync(x => x.Id == IdEleccion)).MapTo<EleccionDto>();
            }
        }
    
}
