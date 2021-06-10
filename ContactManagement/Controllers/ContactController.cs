using DomainModel.Contact;
using IBLL.IService;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManagement.Controllers
{
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: api/Contacts
        [HttpGet]
        [Route("Contacts")]
        public IHttpActionResult Contacts()
        {
            return Ok<IEnumerable<Contact>>(_contactService.GetContacts().ToList());
        }

        // GET: api/GetContact/5
        [HttpGet]
        [Route("Contact/{id}")]
        public Contact Contact(int id)
        {
            Contact data = _contactService.GetContact(id);

            if (data == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                     Content = new StringContent(string.Format("No Contact found with ID = {0}", id)),  
                     ReasonPhrase = "Contact Not Found"
                };

                throw new HttpResponseException(response);
            }
            return data;
        }

        // POST: api/CreateContact
        [HttpPost]
        [Route("AddContact")]
        public Contact Contact([FromBody]Contact contact)
        {
            return _contactService.CreateContact(contact);
        }

        // PUT: api/ChangeContactStatus/5
        [HttpPut]
        [Route("UpdateContact")]
        public bool UpdateContactStatus([FromBody]Contact contact)
        {
            return _contactService.ChangeContactStatus(contact);
        }


    }
}
