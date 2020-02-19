using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TopCine.Domain.Features.Users;

namespace TopCine.Infra.ORM.Context
{
    public class TopCineProcessContext : DbContext
    {

        public TopCineProcessContext(DbContextOptions<TopCineProcessContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("process");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TopCineProcessContext).Assembly);
        }

        public DbSet<User> Users { get; set; }


    }
}
