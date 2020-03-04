using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Manufacturers
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Cars> Cars { get; set; }

        public virtual ICollection<Details> Details { get; set; }
    }
}
