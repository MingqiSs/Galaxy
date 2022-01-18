using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Galaxy.Product.Domin.Data
{
    public class GalaxyProductDbMigrationService : ITransientDependency
    {
        public ILogger<GalaxyProductDbMigrationService> Logger { get; set; }
        private readonly IDataSeeder _dataSeeder;
        private readonly IEnumerable<IGalaxyProductDbSchemaMigrator> _dbSchemaMigrators;
        private readonly ICurrentTenant _currentTenant;
        public GalaxyProductDbMigrationService(
         IDataSeeder dataSeeder,
         IEnumerable<IGalaxyProductDbSchemaMigrator> dbSchemaMigrators,
         ICurrentTenant currentTenant)
        {
            _dataSeeder = dataSeeder;
            _dbSchemaMigrators = dbSchemaMigrators;
            _currentTenant = currentTenant;
        }
        public async Task MigrateAsync()
        {
            Logger.LogInformation("Started database migrations...");
            await MigrateDatabaseSchemaAsync();
            Logger.LogInformation("Successfully completed database migrations.");
        }
        private async Task MigrateDatabaseSchemaAsync()
        {
            foreach (var migrator in _dbSchemaMigrators)
            {
                await migrator.MigrateAsync();
            }
        }
    }

}
