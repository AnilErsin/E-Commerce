using Microsoft.EntityFrameworkCore;
using Project.Dal.Context;
using Project5.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private  ProjectContext _contex;
        private DbSet<T> _entities;

        public BaseRepository(ProjectContext contex)
        {
            _contex = contex;
            _entities = _contex.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Insert(T entity)
        {

            if (entity != null)
            {
                _entities.Add(entity);
                SaveChanges();

            }
        }

        public void Remove(T entity)
        {
            if (entity != null)
            {
                _entities.Remove(entity);
                SaveChanges();
            }
        }

        public string SaveChanges()
        {
            try
            {
                _contex.SaveChanges();
                return "İşlem Başarıyla Gerçekleşti!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public void Update(T entity)
        {
            if (entity !=null)
            {
                _contex.Entry(entity).State = EntityState.Modified;
                SaveChanges();
            }
        }
    }
}
