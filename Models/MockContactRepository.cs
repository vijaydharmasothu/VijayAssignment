using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Models
{
    public class MockContactRepository : IContactRepository
    {
        private List<Contact> _contacts;

        public MockContactRepository()
        {
            if(_contacts==null)
            InitializeContacts();
        }

        private void InitializeContacts()
        {
            _contacts = new List<Contact>
            {
                //new Contact{ ContactId = 1, FisrtName="Vijay", LattName="Dharmasothu",Email="hivijju@gmail.com",PhoneNumber= 9850848128,Status="Active" },
                //new Contact{ ContactId = 2,FisrtName="Siddhu", LattName="Dharmasothu",Email="siddu@gmail.com",PhoneNumber= 9850848128,Status="Active" }
            };

        }
        public IEnumerable<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public void Insert(Contact contact)
        {
            int nextId = 1;
            var lastContact = _contacts.OrderByDescending(i => i.ContactId).FirstOrDefault();
            if(lastContact != null)
            {
                nextId = lastContact.ContactId + 1;
            }
            contact.ContactId = nextId;
            _contacts.Add(contact);            
        }

        public void Update(Contact contact)
        {
            _contacts.RemoveAll(x => x.ContactId == contact.ContactId);
            _contacts.Add(contact);
        }

        public void Remove(Contact contact)
        {
            _contacts.Remove(contact);

        }
    }
}
