using System.Collections.Generic;
using AutoMapper;
using ContactsDemo.Domain;
using ContactsDemo.Domain.DTO;
using ContactsDemo.Domain.Interfaces;
using ContactsWebAPI.Util;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all existent Contacts which are Natural Person
        /// </summary>
        /// <returns></returns>
        [HttpGet("NaturalPerson")]
        public IEnumerable<NaturalPersonContactDTO> GetNaturalPerson()
        {
            var contacts = _contactRepository.GetAllNaturalPerson();
            foreach (var contact in contacts)
                yield return _mapper.Map<NaturalPersonContactDTO>(contact);
        }

        /// <summary>
        /// Lists all existent Contacts which are Legal Person
        /// </summary>
        /// <returns></returns>
        [HttpGet("LegalPerson")]
        public IEnumerable<LegalPersonContactDTO> GetLegalPerson()
        {
            var contacts = _contactRepository.GetAllLegalPerson();
            foreach (var contact in contacts)
                yield return _mapper.Map<LegalPersonContactDTO>(contact);
        }

        /// <summary>
        /// Gets a Natural Person contact by its id
        /// </summary>
        /// <returns></returns>
        [HttpGet("NaturalPerson/{id}")]
        public ActionResult<NaturalPersonContactDTO> GetNaturalPerson(int id)
        {
            var contact = _contactRepository.GetContactById<NaturalPerson>(id);
            if (contact != null)
                return _mapper.Map<NaturalPersonContactDTO>(contact);
            else
                return NotFound($"Contact \"{id}\" not found!");
        }

        /// <summary>
        /// Gets a Legal Person contact by its id
        /// </summary>
        /// <returns></returns>
        [HttpGet("LegalPerson/{id}")]
        public ActionResult<LegalPersonContactDTO> GetLegalPerson(int id)
        {
            var contact = _contactRepository.GetContactById<LegalPerson>(id);
            if (contact != null)
                return _mapper.Map<LegalPersonContactDTO>(contact);
            else
                return NotFound($"Contact \"{id}\" not found!");
        }


        /// <summary>
        /// Delete a Contact by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_contactRepository.GetByPrimaryKey(id) != null)
            {
                _contactRepository.Delete(id);
                return Ok("Contact deleted successfully");
            }
            else
                return NotFound($"Contact \"{id}\" not found!");
        }


        /// <summary>
        /// Receive a Contact of Legal Person to save
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("LegalPerson")]
        public ActionResult<LegalPersonContactDTO> PostLegalPerson(LegalPersonContactDTO contactDTO)
        {

            if (!contactDTO.IsCNPJValid())
            {
                ModelState.AddModelError("CNPJ", "Invalid CNPJ! Must follow the pattern xx.xxx.xxx/xxxx-xx");
                return BadRequest(ModelState);
            }

            ContactDTOMapper mapper = new ContactDTOMapper(_mapper);
            var contact = mapper.MapFromLegalPersonContactDTO(contactDTO);

            _contactRepository.SaveOrUpdate(contact);

            contactDTO = _mapper.Map<LegalPersonContactDTO>(contact);

            return contactDTO;
        }

        /// <summary>
        /// Receive a Contact of Natural Person to save
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("NaturalPerson")]
        public ActionResult<NaturalPersonContactDTO> PostNaturalPerson(NaturalPersonContactDTO contactDTO)
        {

            if (!contactDTO.IsCPFValid())
            {
                ModelState.AddModelError("CPF", "Invalid CPF! Must follow the pattern xxx.xxx.xxx-xx");
                return BadRequest(ModelState);
            }

            ContactDTOMapper mapper = new ContactDTOMapper(_mapper);
            var contact = mapper.MapFromNaturalPersonContactDTO(contactDTO);

            _contactRepository.SaveOrUpdate(contact);

            contactDTO = _mapper.Map<NaturalPersonContactDTO>(contact);

            return contactDTO;
        }
    }
}
