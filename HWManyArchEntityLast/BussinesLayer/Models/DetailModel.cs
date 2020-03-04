using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Models
{
    public class DetailModel
    {
        public int Id { get; set; }
        public string NameDetail { get; set; }
        public int Number { get; set; }

        public int Price { get; set; }

        public int CarId { get; set; }
        public CarModel CarModel { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerModel Manufacturer { get; set; }
    }
}
