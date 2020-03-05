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
    public class DetailsService : IDBService<DetailModel>
    {
        private readonly IDBRepository<Details> _carDetailsRepository;
        public DetailsService()
        {
            _carDetailsRepository = new DetailRepository();
        }

        public IEnumerable<DetailModel> GetAll()
        {

            var details = from detail in _carDetailsRepository.GetAll()
                          select new DetailModel
                          {
                              Id = detail.Id,
                              NameDetail = detail.NameDetail,
                              Price = detail.Price,
                              CarModel = new CarModel
                              {
                                  Id = detail.Car.Id,
                                  Name = detail.Car.Name
                              },
                              CarId = detail.CarsId,
                              //Type = (DetailTypeEnum)detail.DetailTypeId,
                              Manufacturer = new ManufacturerModel
                              {
                                  Id = detail.Manufacturer.Id,
                                  Name = detail.Manufacturer.Name
                              }
                          };


            return details.ToList();
        }

        public void Delete(int id)
        {
            _carDetailsRepository.Delete(id);
        }

        public void Add(DetailModel detailModel)
        {
            //var car = _dbCar.GetAll().Where(x => x.Id == detailModel.CarId).FirstOrDefault();

            var detail = new Details
            {
                NameDetail = detailModel.NameDetail,
                Price = detailModel.Price,
                CarsId = detailModel.CarId,
                Manufacturer = new Manufacturers
                {
                    Id = detailModel.ManufacturerId
                }  //TODO:check      
            };

            _carDetailsRepository.Insert(detail);
        }

        public void Update(DetailModel detailModel)
        {
            var detail = new Details
            {
                Id = detailModel.Id,

                NameDetail = detailModel.NameDetail,
                Price = detailModel.Price
            };

            _carDetailsRepository.Update(detail);
        }

        public DetailModel GetId(int id)
        {
            var detail = _carDetailsRepository.GetId(id);

            var detailModel = new DetailModel
            {
                Id = detail.Id,
                NameDetail = detail.NameDetail,
                Price = detail.Price,
                CarModel = new CarModel
                {
                    Id = detail.Car.Id,
                    Name = detail.Car.Name,
                },
                //Type = (DetailTypeEnum)detail.DetailTypeId,
                Manufacturer = new ManufacturerModel
                {
                    Id = detail.Manufacturer.Id,
                    Name = detail.Manufacturer.Name
                }
            };

            return detailModel;
        }

        public ManufacturerModel GetMostExpensive()
        {
            throw new NotImplementedException();
        }

        public string ValidationCarUniq(string v)
        {
            throw new NotImplementedException();
        }
    }
}
