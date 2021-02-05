using ContactsDemo.Domain.Interfaces;
using ContactsWebAPI.DTO;
using System;

namespace ContactsDemo.Services
{
    public class ContactService : IContactService
    {
        public LegalPersonContactDTO SaveContact(LegalPersonContactDTO legalPersonContactDTO)
        {
            throw new NotImplementedException();
        }

        public NaturalPersonContactDTO SaveContact(NaturalPersonContactDTO legalPersonContactDTO)
        {
            throw new NotImplementedException();
        }
    }
}
