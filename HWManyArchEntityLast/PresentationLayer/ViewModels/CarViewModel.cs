using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PresentationLayer.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DetailViewModel> Details { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerViewModel Manufacturer { get; set; }
    }
}
