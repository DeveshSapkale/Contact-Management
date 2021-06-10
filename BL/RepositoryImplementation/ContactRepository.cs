using IBLL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Contact;
using Data;
using Infrastructure;
using AutoMapper;

namespace BL.RepositoryImplementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationContext _applicationContact;

        public ContactRepository()
        {
            _applicationContact = new ApplicationContext();
        }

        public Contact CreateContact(Contact contact)
        {
            _applicationContact.Contacts.Add(contact);
            _applicationContact.SaveChanges();
            return contact;
        }

        public bool ChangeContactStatus(Contact contact)
        {
            var dbConctact = _applicationContact.Contacts.SingleOrDefault(c => c.ContactId == contact.ContactId);
            if (dbConctact == null)
            {
                return false;
            }
            dbConctact.Status = contact.Status;
            _applicationContact.SaveChanges();
            return true;
        }

        public Contact EditContact(Contact contact)
        {
            var dbConctact = _applicationContact.Contacts.SingleOrDefault(c => c.ContactId == contact.ContactId);
            Mapper.Map<Contact, Contact>(contact, dbConctact);
            _applicationContact.SaveChanges();
            return dbConctact;
        }

        public Contact GetContact(int id)
        {
            return  _applicationContact.Contacts.SingleOrDefault(c => c.ContactId == id);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _applicationContact.Contacts;
        }
    }
}
