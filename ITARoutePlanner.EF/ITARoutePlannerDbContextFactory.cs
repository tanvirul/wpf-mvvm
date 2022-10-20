using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITARoutePlanner.EF
{
    public class ITARoutePlannerDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public ITARoutePlannerDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public ITARoutePlannerDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<ITARoutePlannerDbContext> options = new DbContextOptionsBuilder<ITARoutePlannerDbContext>();

            _configureDbContext(options);

            return new ITARoutePlannerDbContext(options.Options);
        }
    }
}
