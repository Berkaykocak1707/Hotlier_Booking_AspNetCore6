using Entities.Dtos;
using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(int contactId);
        void CreateContact(ContactDtoForCreation dtoContactCreate);
        void DeleteContact(int contactId);
    }
}
