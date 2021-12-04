using HouseSelfInspection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSelfInspection
{
    public class InspectionContext: DbContext 
    {
        public InspectionContext(DbContextOptions<InspectionContext> options) : base(options)
        {

        }

        public DbSet<HouseModel> houses { get; set; }
    }
}
