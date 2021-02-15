using ContactsDemo.Domain.Classes;
using System;

namespace ContactsDemo.Domain
{
    public class Contact : BaseEntity
    {
        private Contact()
        {

        }
        public Contact(Person person, Address address)
        {
            Person = person;
            Address = address;
        }

        public Person Person { get; set; }
        public Address Address { get; set; }
    }
}
