using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Details
    {
        public int Id { get; set; }
        public string NameDetail { get; set; }
        public int Number { get; set; }

        public int Price { get; set; }

        public int CarsId { get; set; }
        public virtual Cars Car { get; set; }

        public int ManufacturerId { get; set; }
        public virtual Manufacturers Manufacturer { get; set; }
    }

}
