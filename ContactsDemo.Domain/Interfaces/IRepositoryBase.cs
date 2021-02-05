using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Domain.Interfaces
{
    public interface IRepositoryBase<TModel> where TModel : BaseEntity
    {
        public void SaveOrUpdate(TModel contact);
        public void Delete(int id);
        public TModel GetByPrimaryKey(int Id);
        public List<TModel> Get();
    }
}
