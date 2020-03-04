using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DetailModel> Details { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerModel Manufacturer { get; set; }
    }


}
