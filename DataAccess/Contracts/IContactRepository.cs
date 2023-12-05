using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(int contactId);
        void CreateContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}
