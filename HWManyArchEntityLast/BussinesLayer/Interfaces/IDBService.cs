using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLayer.Models;

namespace BussinesLayer.Interfaces
{
    public interface IDBService<T> where T:class
    {
        IEnumerable<T> GetAll();
        //IEnumerable<T> GetRich();
        T GetId(int id);
        void Add(T model);
        void Delete(int id);
        void Update(T model);
        string ValidationCar(string v);
    }
}
