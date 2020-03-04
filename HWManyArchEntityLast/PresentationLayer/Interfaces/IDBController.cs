using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Interfaces
{
    public interface IDBController<T> where T : class
    {
        IEnumerable<T> GetAll();
        //IEnumerable<T> GetRich();
        T GetId(int id);
        void Add(T model);
        void Delete(int id);
        void Update(T model);
    }
}
