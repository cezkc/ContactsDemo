using AutoMapper;
using ContactsDemo.Domain;
using ContactsDemo.Domain.DTO;

namespace ContactsDemo.Configuration
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Contact, NaturalPersonContactDTO>()
               .ForMember(dest => dest.AddressLine1, from => from.MapFrom(x => x.Address.AddressLine1))
               .ForMember(dest => dest.AddressLine2, from => from.MapFrom(x => x.Address.AddressLine2))
               .ForMember(dest => dest.City, from => from.MapFrom(x => x.Address.City))
               .ForMember(dest => dest.Country, from => from.MapFrom(x => x.Address.Country))
               .ForMember(dest => dest.State, from => from.MapFrom(x => x.Address.State))
               .ForMember(dest => dest.ZipCode, from => from.MapFrom(x => x.Address.ZipCode))
               .ForMember(dest => dest.Birthday, from => from.MapFrom(x => x.Person.NaturalPerson.Birthday))
               .ForMember(dest => dest.Name, from => from.MapFrom(x => x.Person.NaturalPerson.Name))
               .ForMember(dest => dest.Gender, from => from.MapFrom(x => x.Person.NaturalPerson.Gender))
               .ForMember(dest => dest.CPF, from => from.MapFrom(x => x.Person.NaturalPerson.CPF));

            CreateMap<Contact, LegalPersonContactDTO>()
                .ForMember(dest => dest.AddressLine1, from => from.MapFrom(x => x.Address.AddressLine1))
                .ForMember(dest => dest.AddressLine2, from => from.MapFrom(x => x.Address.AddressLine2))
                .ForMember(dest => dest.City, from => from.MapFrom(x => x.Address.City))
                .ForMember(dest => dest.Country, from => from.MapFrom(x => x.Address.Country))
                .ForMember(dest => dest.State, from => from.MapFrom(x => x.Address.State))
                .ForMember(dest => dest.ZipCode, from => from.MapFrom(x => x.Address.ZipCode))
                .ForMember(dest => dest.CNPJ, from => from.MapFrom(x => (x.Person as LegalPerson).CNPJ))
                .ForMember(dest => dest.CompanyName, from => from.MapFrom(x => (x.Person as LegalPerson).CompanyName))
                .ForMember(dest => dest.TradeName, from => from.MapFrom(x => (x.Person as LegalPerson).TradeName));

            CreateMap<NaturalPersonContactDTO, NaturalPerson>();
            CreateMap<LegalPersonContactDTO, LegalPerson>();
            CreateMap<NaturalPersonContactDTO, Address>();
            CreateMap<LegalPersonContactDTO, Address>();           
        }

    }
}
