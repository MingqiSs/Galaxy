using Galaxy.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Galaxy.Customer.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class CustomerDbContext : AbpDbContext<CustomerDbContext>
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
             : base(options)
        {

        }
        public DbSet<AppCustomer> AppProduct { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppCustomer>(b =>
            {
                b.ToTable("App_Customer");

                //Configure the base properties
                b.ConfigureByConvention();

                //Configure other properties (if you are using the fluent API)
                b.Property(x => x.Name).IsRequired().HasMaxLength(50);
            });
        }

    }
}
