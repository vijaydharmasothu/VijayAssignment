using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Models
{
    // Interface for ContactRepository Implementation and for Dependency injection 
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts();

        void Insert(Contact contact);

        void Update(Contact contact);

        void Remove(Contact contact);
    }
}
