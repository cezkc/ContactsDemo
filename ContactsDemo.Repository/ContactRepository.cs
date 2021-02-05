using ContactsDemo.Domain;
using ContactsDemo.Domain.Classes;
using ContactsDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsDemo.Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository() : base()
        {

        }
        public List<Contact> GetAllLegalPerson()
        {
            return _entityList.Where(x => x.Person is LegalPerson).ToList();
        }

        public List<Contact> GetAllNaturalPerson()
        {
            return _entityList.Where(x => x.Person is NaturalPerson).ToList();
        }

        public Contact GetContactById<PersonModel>(int id) where PersonModel : Person
        {
            var contact = GetByPrimaryKey(id);

            if (!(contact.Person is PersonModel))
                return null;

            return contact;
        }
    }
}
