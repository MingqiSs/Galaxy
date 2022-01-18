
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Galaxy.Product.Domin;

namespace Galaxy.Product.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    class GalaxyProductDbContext : AbpDbContext<GalaxyProductDbContext>
    {
        public GalaxyProductDbContext(DbContextOptions<GalaxyProductDbContext> options)
           : base(options)
        {

        }
        public DbSet<AppProduct> AppProduct { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppProduct>(b =>
            {
                b.ToTable("app_product");

                //Configure the base properties
                b.ConfigureByConvention();

                //Configure other properties (if you are using the fluent API)
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });
        }

    }
}
