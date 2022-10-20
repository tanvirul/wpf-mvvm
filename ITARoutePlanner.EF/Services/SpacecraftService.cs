using ITARoutePlanner.Domain.Models;
using ITARoutePlanner.Domain.Models.Services;
using ITARoutePlanner.EF.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITARoutePlanner.EF.Services
{
    public class SpacecraftService : ISpacecraftService
    {
        private readonly ITARoutePlannerDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Spacecraft> _nonQueryDataService;

        public SpacecraftService(ITARoutePlannerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Spacecraft>(contextFactory);
        }
        public async Task<Spacecraft> Create(Spacecraft entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Spacecraft> Get(int id)
        {
            using (ITARoutePlannerDbContext context = _contextFactory.CreateDbContext())
            {
                Spacecraft entity = await context.Spacecrafts
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Spacecraft>> GetAll()
        {
            using (ITARoutePlannerDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Spacecraft> entities = await context.Spacecrafts
                                     .ToListAsync();
                return entities;
            }
        }

        public Task<Spacecraft> Update(int id, Spacecraft entity)
        {
            throw new NotImplementedException();
        }
    }
}
