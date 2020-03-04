using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class ManufacturerRepository : IDBRepository<Manufacturers>
    {
        private readonly CarDetailsContext _ctx;

        public ManufacturerRepository()
        {
            _ctx = new CarDetailsContext();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manufacturers> GetAll()
        {
            return _ctx.Manufacturers.ToList();
        }

        public Manufacturers GetId(int id)
        {
            var manufacturer = _ctx.Manufacturers.Where(x => x.Id == id).FirstOrDefault();
            return manufacturer;
        }

        public void Insert(Manufacturers model)
        {
            throw new NotImplementedException();
        }

        public void Update(Manufacturers model)
        {
            throw new NotImplementedException();
        }
    }
}
