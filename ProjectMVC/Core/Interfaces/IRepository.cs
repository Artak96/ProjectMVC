using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Core.Interfaces
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
        T GetById(int id);
        IEnumerable<T> List();
    }
}
