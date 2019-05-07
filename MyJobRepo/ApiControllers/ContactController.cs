using AutoMapper;
using MyJobRepo.DataAccess;
using MyJobRepo.Models;
using MyJobRepo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MyJobRepo.ApiControllers
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        private IRepository Repo;
        private IMapper Mapper;

        public ContactController(IRepository repo, IMapper mapper)
        {
            Repo = repo;
            Mapper = mapper;
        }

        [Route("all")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await Repo.GetAllContactsAsync();

                // mapping
                var mappedResult = Mapper.Map<IEnumerable<ContactModel>>(result);
                if (result == null) return NotFound();

                return Ok(mappedResult);
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }

        }

        [Route("ById/{ContactId}")]
        public async Task<IHttpActionResult> Get(int contactId)
        {
            try
            {
                var result = await Repo.GetContactAsync(contactId);

                // mapping
                var mappedResult = Mapper.Map<ContactModel>(result);
                if (result == null) return NotFound();

                //return Ok(mappedResult);
                return Ok(Mapper.Map<ContactModel>(result));
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }
        }


        [Route("ByType/{ContactType}")]
        public async Task<IHttpActionResult> Get(string contactType)
        {
            switch (contactType)
            {
                case "HR":
                    contactType = "HR Representative";
                    break;

                case "HM":
                    contactType = "Hiring Manager";
                    break;

                case "SR":
                    contactType = "Senior Developer";
                    break;

                case "AM":
                    contactType = "Account Manager";
                    break;

                default:
                    break;
            }
            try
            {
                var result = await Repo.GetContactsByContactTypeAsync(contactType);

                // mapping
                var mappedResult = Mapper.Map<IEnumerable<ContactModel>>(result);
                if (result == null) return NotFound();

                return Ok(mappedResult);
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }

        }

        [Route()]
        [HttpPost]
        public HttpResponseMessage Contact(HttpRequestMessage Data)
        {
            var json = Data.Content.ReadAsStringAsync().Result;
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            Dictionary<string, object> contactObject = (Dictionary<string, object>)json_serializer.DeserializeObject(json);

            var contact = new ContactModel();
            contact.CompanyId = Convert.ToInt32(contactObject["CompanyId"]);
            contact.ContactTypeId = Convert.ToInt32(contactObject["ContactTypeId"]);
            contact.ContactName = contactObject["ContactName"].ToString();
            contact.Email = contactObject["Email"].ToString();
            contact.Phone = contactObject["Phone"].ToString();
            contact.Notes = contactObject["Notes"].ToString();

            ContactService service = new ContactService();
            bool success = service.SaveNewContact(contact);

            HttpResponseMessage message = new HttpResponseMessage();
            if (success)
            {
                message.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                message.StatusCode = HttpStatusCode.InternalServerError;
            }
            return message;
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
        }
    }
}
