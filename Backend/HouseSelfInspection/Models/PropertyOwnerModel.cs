using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSelfInspection.Models
{
    public class PropertyOwnerModel
    {
        public int OwnerID { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }
    }
}
