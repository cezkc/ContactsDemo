using ContactsDemo.Domain;
using ContactsDemo.Domain.Classes;
using ContactsDemo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsDemo.Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        private readonly ApplicationContext _context;
        public ContactRepository(ApplicationContext context) : base(context)
        {
            context.Contacts.Include(x => x.Person).Include(x => x.Address);
            _context = context;
        }

        public override IQueryable<Contact> Get()
        {
            return base.Get().Include(x => x.Address).Include(x => x.Person);
        }

        public List<Contact> GetAllLegalPerson()
        {
            return Get().Where(x => x.Person.IsLegalPerson).ToList();
        }

        public List<Contact> GetAllNaturalPerson()
        {
            return Get().Where(x => x.Person.IsNaturalPerson).ToList();
        }

        public Contact GetContactById<PersonModel>(int id) where PersonModel : Person
        {
            var contact = GetByPrimaryKey(id).Include(x => x.Person).Include(x => x.Address).FirstOrDefault();

            if (!(contact.Person is PersonModel))
                return null;

            return contact;
        }

        public override void SaveOrUpdate(Contact entity)
        {
            base.SaveOrUpdate(entity);
        }
    }
}
