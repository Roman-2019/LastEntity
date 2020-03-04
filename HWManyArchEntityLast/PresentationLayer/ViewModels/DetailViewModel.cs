using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class DetailViewModel
    {
        public int Id { get; set; }
        public string NameDetail { get; set; }
        public int Number { get; set; }

        public int Price { get; set; }

        public int CarId { get; set; }
        public CarViewModel CarViewModel { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerViewModel Manufacturer { get; set; }

    }
}
