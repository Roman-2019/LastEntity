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
    public class ManufacturerController : IDBController<ManufacturerViewModel>
    {
        private readonly IDBService<ManufacturerModel> _manufacturerservice;
        public ManufacturerController()
        {
            _manufacturerservice = new ManufacturerService();
        }

        public void Add(ManufacturerViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ManufacturerViewModel> GetAll()
        {
            var manuf = from manufacturer in _manufacturerservice.GetAll()
                        select new ManufacturerViewModel
                        {
                            Id = manufacturer.Id,
                            Name = manufacturer.Name,
                            CarsModel = manufacturer.CarsModel.Select(x => new CarViewModel
                            {
                                Id = x.Id,
                                Name = x.Name,
                                ManufacturerId = x.ManufacturerId,
                                Details = x.Details.Select(y => new DetailViewModel
                                {
                                    Id = y.Id,
                                    Price = y.Price,
                                    ManufacturerId = y.ManufacturerId,
                                }),
                            }),
                            DetailsModel = manufacturer.DetailsModel.Select(x => new DetailViewModel
                            {
                                Id = x.Id,
                                NameDetail = x.NameDetail,
                                Price = x.Price,
                                ManufacturerId = x.ManufacturerId
                            })
                        };
            return manuf.ToList();
        }

        public ManufacturerViewModel GetId(int id)
        {
            var manuf = _manufacturerservice.GetId(id);

            var manufModel = new ManufacturerViewModel
            {
                Id = manuf.Id,
                Name = manuf.Name,
                CarsModel = manuf.CarsModel.Select(x => new CarViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ManufacturerId = x.ManufacturerId,
                    Details = x.Details.Select(y => new DetailViewModel
                    {
                        Id = y.Id,
                        Price = y.Price,
                        ManufacturerId = y.ManufacturerId,
                    }),
                }),
                DetailsModel = manuf.DetailsModel.Select(x => new DetailViewModel
                {
                    Id = x.Id,
                    NameDetail = x.NameDetail,
                    Price = x.Price,
                    ManufacturerId = x.ManufacturerId
                })
            };
            return manufModel;
        }

        public void Update(ManufacturerViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
