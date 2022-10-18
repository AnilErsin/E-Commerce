using Project5.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repository
{
    public interface IRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);

        void Remove(T entity);
        void Update(T entity);

        T GetById(int id);

        string SaveChanges();
    }
}
