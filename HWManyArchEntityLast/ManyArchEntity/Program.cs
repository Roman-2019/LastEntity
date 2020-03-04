using PresentationLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLayer.Services;
using BussinesLayer.Models;

namespace ManyArchEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            var carController = new CarsController();
            var detailController = new DetailsController();
            var manufacturerController = new ManufacturerController();
            var manufacturerService = new ManufacturerService();
            //var allCars = carController.GetAll();
            //var carById = carController.GetId(1);
            var allDetails = detailController.GetAll();
            //var detailById = detailController.GetId(2);
            //detailController.Insert(null);
            //detailController.Update(null);
            //detailController.Delete(1002);


            //carController.Insert(null);
            //carController.Update(null);
            //carController.Delete(6);

            var allManufacturers = manufacturerController.GetAll();
            //var richcars = manufacturerController.GetRich();
            var mostexpensive = manufacturerService.GetMostExpensive();
            Console.ReadKey();
        }
    }
}
