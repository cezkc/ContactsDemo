using ContactsDemo.Domain;
using ContactsDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsDemo.Repository
{
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : BaseEntity
    {
        internal HashSet<TModel> _entityList = new HashSet<TModel>();
        public void Delete(int id)
        {
            _entityList.RemoveWhere(x => x.Id == id);
        }

        public List<TModel> Get()
        {
            return _entityList.ToList();
        }

        public virtual TModel GetByPrimaryKey(int Id)
        {
            return _entityList.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void SaveOrUpdate(TModel contact)
        {
            if (_entityList.Any(x => x.Id == contact.Id))
            {
                _entityList.RemoveWhere(x => x.Id == contact.Id);
                _entityList.Add(contact);
            }
            else
            {
                contact.Id = (_entityList.Any() ? _entityList.Max(x => x.Id) : 0) + 1;
                _entityList.Add(contact);
            }

        }
    }
}
