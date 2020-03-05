using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLayer.Interfaces;
using BussinesLayer.Models;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;

namespace BussinesLayer.Services
{
    public class CarsService : IDBService<CarModel>
    {
        private readonly IDBRepository<Cars> _carDetailsRepository;
        
        public CarsService() 
        {
            _carDetailsRepository = new CarRepository();
            
        }

        public void Add(CarModel carModel)
        {
            var car = new Cars
            {
                Name = carModel.Name,
                Details = carModel.Details.Select(x => new Details
                {
                    NameDetail = x.NameDetail,
                    Price = x.Price,
                    CarsId = x.CarId,
                    //DetailTypeId = (int)x.Type,
                    ManufacturerId = x.ManufacturerId
                }
                ).ToList(),
                ManufacturerId = carModel.ManufacturerId
            };

            _carDetailsRepository.Insert(car);
        }

        public void Delete(int id)
        {
            _carDetailsRepository.Delete(id);
        }

        public IEnumerable<CarModel> GetAll()
        {

            var carModels = from car in _carDetailsRepository.GetAll()
                            select new CarModel()
                            {
                                Id = car.Id,
                                Name = car.Name,
                                Details = car.Details.Select(x => new DetailModel
                                {
                                    Id = x.Id,
                                    NameDetail = x.NameDetail,
                                    Price = x.Price,
                                    CarId = x.CarsId,
                                    Manufacturer = new ManufacturerModel
                                    {
                                        Id = x.Manufacturer.Id,
                                        Name = x.Manufacturer.Name
                                    }
                                }),
                                Manufacturer = new ManufacturerModel
                                {
                                    Id = car.Manufacturer.Id,
                                    Name = car.Manufacturer.Name,
                                },
                            };
            return carModels;
        }

        public void Update(CarModel carModel)
        {
            var car = new Cars
            {
                Id = carModel.Id,
                Name = carModel.Name
            };

            car.Name = carModel.Name;

            _carDetailsRepository.Update(car);
        }

        public CarModel GetId(int id)
        {
            var car = _carDetailsRepository.GetId(id);

            var carModel = new CarModel
            {
                Id = car.Id,
                Name = car.Name,
                Details = car.Details.Select(x => new DetailModel
                {
                    Id = x.Id,
                    NameDetail = x.NameDetail,
                    Price = x.Price,
                    CarId = x.CarsId,
                    Manufacturer = new ManufacturerModel
                    {
                        Id = x.Manufacturer.Id,
                        Name = x.Manufacturer.Name
                    }
                }),
                Manufacturer = new ManufacturerModel
                {
                    Id = car.Manufacturer.Id,
                    Name = car.Manufacturer.Name
                }

            };

            return carModel;
        }

        public ManufacturerModel GetMostExpensive()
        {
            throw new NotImplementedException();
        }


        public string ValidationCarUniq(string name)
        {
            var carAll = _carDetailsRepository.GetAll();
            var currentName = carAll.FirstOrDefault(x => x.Name == name);


            if (currentName == null)
            {
                return name;
            }
            else
            {
                throw new ArgumentException();
            }
        }

    }
}
