using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSelfInspection.Models
{
    public class TenantModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public int HouseID { get; set; }

        public DateTime StartDate { get; set; }


    }
}
