
using Elecciones.Service.Query.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votaciones.Persistence.Database;

namespace Votaciones.Service.Query
{
    public interface IVotacionQueryService
    {
        Task<DataCollection<VotacionDto>> GetAllAsync(int page, int take, IEnumerable<long> Votacion = null);

        Task<VotacionDto> GetAsync(int IdEleccion);
    }
    public class VotacionQueryService : IVotacionQueryService
    {
        private readonly ApplicationDbContext _context;

        public VotacionQueryService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<VotacionDto>> GetAllAsync(int page, int take, IEnumerable<long> Votacion = null)
        {
            var collection = await _context.Tbl_Votacion
                                    .Where(x => Votacion == null || Votacion.Contains(x.Id))
                                    .OrderByDescending(x => x.Id)
                                    .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<VotacionDto>>();
        }

        public async Task<VotacionDto> GetAsync(int IdEleccion)
        {
            return (await _context.Tbl_Votacion.SingleAsync(x => x.Id == IdEleccion)).MapTo<VotacionDto>();
        }
    }

}
