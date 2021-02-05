using AutoMapper;
using ContactsDemo.Domain;
using ContactsDemo.Domain.DTO;

namespace ContactsWebAPI.Util
{
    public class ContactDTOMapper
    {
        private readonly IMapper _mapper;
        public ContactDTOMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Contact MapFromLegalPersonContactDTO(LegalPersonContactDTO legalPersonContactDTO)
        {
            var address = _mapper.Map<Address>(legalPersonContactDTO);
            var legalPerson = _mapper.Map<LegalPerson>(legalPersonContactDTO);
            var contact = new Contact(legalPerson, address);
            contact.Id = legalPersonContactDTO.Id;

            return contact;
        }

        public Contact MapFromNaturalPersonContactDTO(NaturalPersonContactDTO naturalPersonContactDTO)
        {
            var address = _mapper.Map<Address>(naturalPersonContactDTO);
            var naturalPerson = _mapper.Map<NaturalPerson>(naturalPersonContactDTO);
            var contact = new Contact(naturalPerson, address);
            contact.Id = naturalPersonContactDTO.Id;

            return contact;
        }
    }
}
