using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSelfInspection.Models
{
    public class LoginModel
    {
        [Key]
        public int User_ID { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public Boolean isAdmin { get; set; }
    }
}
