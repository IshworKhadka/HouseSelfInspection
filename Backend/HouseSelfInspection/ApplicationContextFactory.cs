using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSelfInspection
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=HouseSelfInspection;Trusted_Connection=True; MultipleActiveResultSets=True;");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
