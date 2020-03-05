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
    public class DetailsController : IDBController<DetailViewModel>
    {
        private readonly IDBService<DetailModel> _cardetailsservice;
        public DetailsController()
        {
            _cardetailsservice = new DetailsService();
        }

        public void Add(DetailViewModel detailViewModel)
        {
            var detail = new DetailModel
            {
                NameDetail = "Engine",
                Price = 1280,
                CarId = 2,
                ManufacturerId = 2
            };
            _cardetailsservice.Add(detail);
        }

        public void Delete(int id)
        {
            _cardetailsservice.Delete(id);
        }

        public IEnumerable<DetailViewModel> GetAll()
        {
            var detailViewModel = from detail in _cardetailsservice.GetAll()
                                  select new DetailViewModel
                                  {
                                      NameDetail = detail.NameDetail,
                                      Price = detail.Price,
                                      CarViewModel = new CarViewModel
                                      {
                                          Id = detail.CarModel.Id,
                                          Name = detail.CarModel.Name,
                                      },
                                      CarId = detail.CarId,
                                      Manufacturer = new ManufacturerViewModel
                                      {
                                          Id = detail.Manufacturer.Id,
                                          Name = detail.Manufacturer.Name
                                      }
                                  };
            return detailViewModel.ToList();
        }

        public void Update(DetailViewModel detailViewModel)
        {
            var detailModel = new DetailModel
            {
                Id = 1,
                NameDetail = "BestDetail",
                Price = 9900,
            };

            _cardetailsservice.Update(detailModel);
        }

        public DetailViewModel GetId(int id)
        {
            var detailModel = _cardetailsservice.GetId(id);

            var detailViewModel = new DetailViewModel
            {
                Id = detailModel.Id,
                NameDetail = detailModel.NameDetail,
                Price = detailModel.Price,
                CarViewModel = new CarViewModel
                {
                    Id = detailModel.CarModel.Id,
                    Name = detailModel.CarModel.Name,
                },
                CarId = detailModel.CarId,
                Manufacturer = new ManufacturerViewModel
                {
                    Id = detailModel.Manufacturer.Id,
                    Name = detailModel.Manufacturer.Name
                }
            };

            return detailViewModel;
        }
    }
}
