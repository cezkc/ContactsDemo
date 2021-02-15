using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsDemo.Domain.Interfaces
{
    public interface IRepositoryBase<TModel> where TModel : BaseEntity
    {
        public void SaveOrUpdate(TModel contact);
        public void Delete(int id);
        public IQueryable<TModel> GetByPrimaryKey(int Id);
        public IQueryable<TModel> Get();
    }
}
