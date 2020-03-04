using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class CarRepository : IDBRepository<Cars>
    {
        private readonly CarDetailsContext _ctx;

        public CarRepository()
        {
            _ctx = new CarDetailsContext();
        }


        public void Delete(int id)
        {
            var car = GetId(id);

            _ctx.Cars.Remove(car);
            _ctx.SaveChanges();
        }

        public IEnumerable<Cars> GetAll()
        {
            return _ctx.Cars.AsNoTracking().ToList();
        }

        public void Insert(Cars car)
        {
            _ctx.Cars.Add(car);
            _ctx.SaveChanges();
        }

        public void Update(Cars car)
        {
            var updatedCar = GetId(car.Id);

            updatedCar.Name = car.Name;

            _ctx.Entry(updatedCar);
            _ctx.SaveChanges();
        }

        public Cars GetId(int id)
        {
            var car = _ctx.Cars.Where(x => x.Id == id).FirstOrDefault();
            return car;
        }
    }
}
