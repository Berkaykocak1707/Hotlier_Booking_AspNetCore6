using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class ContactManager : IContactService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ContactManager(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateContact(ContactDtoForCreation dtoContactCreate)
        {
            Contact contact = _mapper.Map<Contact>(dtoContactCreate);
            _repository.contactRepository.CreateContact(contact);
            _repository.Save();
        }

        public void DeleteContact(int contactId)
        {
            var contact = _repository.contactRepository.GetContactById(contactId);
            _repository.contactRepository.DeleteContact(contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            var contacts = _repository.contactRepository.GetAllContacts();
            return contacts;
        }

        public Contact GetContactById(int contactId)
        {
            var contact = _repository.contactRepository.GetContactById(contactId);
            return contact;
        }
    }
}
