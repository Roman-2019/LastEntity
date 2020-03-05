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
    public class ManufacturerService: IDBService<ManufacturerModel>
    {
        private readonly IDBRepository<Manufacturers> _manufacturerRepository;

        public ManufacturerService()
        {
            _manufacturerRepository = new ManufacturerRepository();

        }

        public IEnumerable<ManufacturerModel> GetAll()
        {
            var manuf = from manufacturer in _manufacturerRepository.GetAll()
                        select new ManufacturerModel
                        {
                            Id = manufacturer.Id,
                            Name = manufacturer.Name,
                            CarsModel = manufacturer.Cars.Select(x => new CarModel
                            {
                                Id = x.Id,
                                Name = x.Name,
                                ManufacturerId = x.ManufacturerId,
                                Details = x.Details.Select(y => new DetailModel
                                {
                                    Id = y.Id,
                                    Price = y.Price,
                                    ManufacturerId = y.ManufacturerId,
                                }),
                            }),
                            DetailsModel = manufacturer.Details.Select(x => new DetailModel
                            {
                                Id = x.Id,
                                NameDetail = x.NameDetail,
                                Price = x.Price,
                                ManufacturerId = x.ManufacturerId
                            })
                        };
            return manuf.ToList();
        }

        public int checkManufactorer(int id)
        {
            var chosenManuf = _manufacturerRepository.GetId(id);

            var manufacturers = _manufacturerRepository.GetAll();

            var deniedManufacturer = manufacturers.FirstOrDefault(x => x.Id == 1);

            if (chosenManuf == deniedManufacturer)
            {
                throw new NotImplementedException();
            }
            else
            {
                return chosenManuf.Id;
            }
        }

        public ManufacturerModel GetId(int id)
        {
            var manuf = _manufacturerRepository.GetId(id);

            var manufModel = new ManufacturerModel
            {
                Id = manuf.Id,
                Name = manuf.Name,
                CarsModel = manuf.Cars.Select(x => new CarModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ManufacturerId = x.ManufacturerId,
                    Details = x.Details.Select(y => new DetailModel
                    {
                        Id = y.Id,
                        Price = y.Price,
                        ManufacturerId = y.ManufacturerId,
                    }),
                }),
                DetailsModel = manuf.Details.Select(x => new DetailModel
                {
                    Id = x.Id,
                    NameDetail = x.NameDetail,
                    Price = x.Price,
                    ManufacturerId = x.ManufacturerId
                })
            };
            return manufModel;
        }

        public CarManufacturerModel GetMostExpensive()
        {
            var sumdetail = _manufacturerRepository.GetAll().OrderBy(x => x.Cars.Max(y => y.Details.Sum(z => z.Price))).FirstOrDefault();
            var mostexpensive = sumdetail.Cars.Select(x => new CarModel
            {
                Id = x.Id,
                Name = x.Name,
                Details = x.Details.Select(y => new DetailModel
                {
                    Id = y.Id,
                    NameDetail = y.NameDetail,
                    Price = y.Price,
                }),
            }).ToList();
            var maxCar = mostexpensive.OrderBy(y => y.Details.Sum(z => z.Price)).FirstOrDefault();


            var result = new CarManufacturerModel
            {
                CarsModel = new CarModel
                {
                    Id = maxCar.Id,
                    Name = maxCar.Name,
                    Details = maxCar.Details.Select(y => new DetailModel
                    {
                        NameDetail = y.NameDetail
                    })
                },
                ManufacturerModel = new ManufacturerModel
                {
                    Id = sumdetail.Id,
                    Name = sumdetail.Name,
                    CarsModel = sumdetail.Cars.Select(x => new CarModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Details = x.Details.Select(y => new DetailModel
                        {
                            Id = y.Id,
                            NameDetail = y.NameDetail,
                            Price = y.Price,
                        })
                    }),
                    DetailsModel = sumdetail.Details.Select(z => new DetailModel
                    {
                        Id = z.Id,
                        NameDetail = z.NameDetail,
                        Price = z.Price,
                        ManufacturerId = z.ManufacturerId
                    })
                }

                //CarId = maxCar.Id,
                //CarName = maxCar.Name,
                //ManufId=sumdetail.Id,
                //ManufName=sumdetail.Name
            };
            return result;

        }

        public void Add(ManufacturerModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ManufacturerModel model)
        {
            throw new NotImplementedException();
        }

    }
}
