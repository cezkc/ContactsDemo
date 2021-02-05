using ContactsDemo.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Domain.Interfaces
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        public List<Contact> GetAllLegalPerson();
        public List<Contact> GetAllNaturalPerson();

        public Contact GetContactById<PersonModel>(int id) where  PersonModel : Person; 
    }
}
