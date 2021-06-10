using DomainModel.Contact;
using IBLL.IRepository;
using IBLL.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ServiceImplementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public bool ChangeContactStatus(Contact contact)
        {
            return _contactRepository.ChangeContactStatus(contact);
        }

        public Contact CreateContact(Contact contact)
        {
            return _contactRepository.CreateContact(contact);
        }

        public Contact EditContact(Contact contact)
        {
            return _contactRepository.EditContact(contact);
        }

        public Contact GetContact(int id)
        {
            return _contactRepository.GetContact(id);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contactRepository.GetContacts();
        }
    }
}
