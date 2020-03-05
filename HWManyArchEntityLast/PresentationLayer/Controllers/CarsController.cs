﻿using System;
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
        private readonly IDBService<CarModel> _carcontroller;
        private readonly IDBService<DetailModel> _detailcontroller;
        private readonly IDBService<ManufacturerModel> _manufcontroller;
        public CarsController() 
        {
            _carcontroller = new CarsService();
            _detailcontroller = new DetailsService();
            _manufcontroller = new ManufacturerService();
        }

        public void Add(CarViewModel carViewModel)
        {
            var addcar = new CarModel
            {
                Name = _carcontroller.ValidationCar("New Car Happy Year"),
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
                _carcontroller.Add(addcar);
        }

        public void Delete(int id)
        {
            _carcontroller.Delete(id);
        }

        public IEnumerable<CarViewModel> GetAll()
        {

            var carViewModels = from car in _carcontroller.GetAll()
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

            _carcontroller.Update(carModel);
        }

        public CarViewModel GetId(int id)
        {
            var carModel = _carcontroller.GetId(id);

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
        //{
        //    //bool flagUniq = false;
        //    var carAll = _carcontroller.GetAll();
        //    var currentName = carAll.FirstOrDefault(x => x.Name == name);
        //    //if (currentName != null)
        //    //{
        //    //    flagUniq = true;
        //    //}

        //    int counter = 0;
        //    //bool flagSpace = false;
        //    for (int z = 0; z < name.Length; z++)
        //    {
        //        if (name[z] == ' ')
        //            counter++;
        //    }
        //    //if (counter > 2)
        //    //    flagSpace = true;

        //    if ((currentName != null) && (counter > 2))
        //    {
        //        return name;
        //    }
        //    else
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
