using Core;
using Core.Service;
using DataAccess.Context;
using Service.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BaseService<T> : ICoreService<T> where T : BaseEntity
    {
        //ProjectDbContext db = new ProjectDbContext();
        ProjectDbContext db = Singleton.Context;

        public void Add(T model)
        {
            model.ID = Guid.NewGuid();
            db.Set<T>().Add(model);
            db.SaveChanges();

        }

        public void Add(List<T> models)
        {
            db.Set<T>().AddRange(models);
            db.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public List<T> GetActive()
        {
            return db.Set<T>().Where(x => x.Status == Core.Enums.Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            var model = db.Set<T>().Find(id);
            db.Set<T>().Remove(model);
            db.SaveChanges();
        }

        public void Update(T model)
        {

            T updated = GetById(model.ID);
           
            DbEntityEntry entry = db.Entry(updated);
            entry.CurrentValues.SetValues(model);
            db.SaveChanges();
        }
    }
}
