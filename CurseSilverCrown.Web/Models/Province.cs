using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurseSilverCrown.Web.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User_Province User_Province { get; set; }
    }
}
