using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
using BussinesLayer.Interfaces;
using BussinesLayer.Models;
using BussinesLayer.Services;

namespace PresentationLayer.Controllers
{
    public class CarsController : IDBController<CarViewModel>
    {
        private readonly IDBService<CarModel> _carsevice;
        public CarsController() 
        {
            _carsevice = new CarsService();
        }

        public void Add(CarViewModel carViewModel)
        {
            var newcar = new CarViewModel 
            {
                Name= "New Car Happy Year"
            };

            if (!IsCarValid(newcar))
                throw new ArgumentException("Car model is Invalid");

            var addcar = new CarModel
            {
                Name = newcar.Name,
                Details = new List<DetailModel>
                {
                    new DetailModel
                    {
                        NameDetail = "Glass",
                        Number = 1234,
                        Price = 1500

                    }
                }
            };
            
                _carsevice.Add(addcar);
        }

        public void Delete(int id)
        {
            _carsevice.Delete(id);
        }

        public IEnumerable<CarViewModel> GetAll()
        {

            var carViewModels = from car in _carsevice.GetAll()
                                select new CarViewModel()
                                {
                                    Id = car.Id,
                                    Name = car.Name,
                                    Details = car.Details.Select(x => new DetailViewModel
                                    {
                                        Id = x.Id,
                                        NameDetail = x.NameDetail,
                                        Price = x.Price,
                                        CarId = x.CarId,
                                        Manufacturer = new ManufacturerViewModel
                                        {
                                            Id = x.Manufacturer.Id,
                                            Name = x.Manufacturer.Name
                                        }
                                    }),
                                    Manufacturer = new ManufacturerViewModel
                                    {
                                        Id = car.Manufacturer.Id,
                                        Name = car.Manufacturer.Name
                                    }
                                };

            return carViewModels;
        }

        public void Update(CarViewModel carViewModel)
        {
            var carModel = new CarModel
            {
                Id = 1,
                Name = "Peugaut"
            };

            _carsevice.Update(carModel);
        }

        public CarViewModel GetId(int id)
        {
            var carModel = _carsevice.GetId(id);

            var carViewModel = new CarViewModel
            {
                Id = carModel.Id,
                Name = carModel.Name,
                Details = carModel.Details.Select(x => new DetailViewModel
                {
                    Id = x.Id,
                    NameDetail = x.NameDetail,
                    Price = x.Price,
                    CarId = x.CarId,
                    Manufacturer = new ManufacturerViewModel
                    {
                        Id = x.Manufacturer.Id,
                        Name = x.Manufacturer.Name
                    }
                }),
                Manufacturer = new ManufacturerViewModel
                {
                    Id = carModel.Manufacturer.Id,
                    Name = carModel.Manufacturer.Name
                }
            };

            return carViewModel;
        }

        //public string ValidationCar(string name)
        public bool IsCarValid(CarViewModel carViewModel)
        {
            int counter = 0;
            for (int z = 0; z < carViewModel.Name.Length; z++)
            {
                if (carViewModel.Name[z] == ' ')
                    counter++;
            }
            if (counter <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
