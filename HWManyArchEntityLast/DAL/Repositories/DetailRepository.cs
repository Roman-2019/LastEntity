using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.SqlServer;

namespace DAL.Repositories
{
    public class DetailRepository : IDBRepository<Details>
    {
        private readonly CarDetailsContext _ctx;

        public DetailRepository()
        {
            _ctx = new CarDetailsContext();
        }


        public void Delete(int id)
        {
            var detail = GetId(id);
            _ctx.Details.Remove(detail);
            _ctx.SaveChanges();
        }

        public IEnumerable<Details> GetAll()
        {
            return _ctx.Details.AsNoTracking().ToList();
        }

        public void Insert(Details detail)
        {
            _ctx.Details.Add(detail);
            _ctx.SaveChanges();
        }

        public void Update(Details detail)
        {
            var updatedDetail = GetId(detail.Id);

            updatedDetail.NameDetail = detail.NameDetail;
            updatedDetail.Price = detail.Price;

            _ctx.Entry(updatedDetail);
            _ctx.SaveChanges();
        }

        public Details GetId(int id)
        {
            var detail = _ctx.Details.Where(x => x.Id == id).FirstOrDefault();

            return detail;
        }
    }
}
