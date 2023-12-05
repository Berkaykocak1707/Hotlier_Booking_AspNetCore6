using DataAccess.Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public sealed class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return FindAll();
        }

        public Contact GetContactById(int contactId)
        {
            var contact = FindByCondition(c => c.ContactID == contactId);
            return contact.FirstOrDefault();
        }

        public void CreateContact(Contact contact)
        {
            Create(contact);
        }

        public void DeleteContact(Contact contact)
        {
            Delete(contact);
        }
    }
}
