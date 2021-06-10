﻿using DomainModel.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL.IService
{
    public interface IContactService
    {
        //Get
        IEnumerable<Contact> GetContacts();
        //Get
        Contact GetContact(int id);
        //Post
        Contact CreateContact(Contact contact);
        //Put
        Contact EditContact(Contact contact);
        //Delete
        bool ChangeContactStatus(Contact contact);
    }
}
