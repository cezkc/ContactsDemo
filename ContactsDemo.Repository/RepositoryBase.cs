using ContactsDemo.Domain;
using ContactsDemo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsDemo.Repository
{
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : BaseEntity
    {
        private readonly ApplicationContext _context;

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var entity = _context.Set<TModel>().Where(x => x.Id == id).FirstOrDefault();
            _context.Set<TModel>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual IQueryable<TModel> Get()
        {
            return _context.Set<TModel>();
        }

        public virtual IQueryable<TModel> GetByPrimaryKey(int Id)
        {
            return _context.Set<TModel>().Where(x => x.Id == Id);
        }

        public virtual void SaveOrUpdate(TModel entity)
        {
            if (entity.Id <= 0)
            {
                //if (_context.Entry(entity).State == EntityState.Detached)
                //   _context.Entry(entity).State = EntityState.Added;
                _context.Set<TModel>().Add(entity);
            }
            else
            {
                _context.Set<TModel>().Update(entity);
            }

            _context.SaveChanges();
        }
    }
}
