using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurseSilverCrown.Web.Models
{
    public class User_Province
    {
        public int ProvinceId { get; set; }
        public string UserId { get; set; }

        public Province Province { get; set; }
        public User User { get; set; }

    }
}
