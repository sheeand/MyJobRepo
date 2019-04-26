﻿using AutoMapper;
using MyJobRepo.Data;
using MyJobRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MyJobRepo.Controllers
{
    public class ContactController : ApiController
    {
        private IRepository Repo;
        private IMapper Mapper;

        public ContactController(IRepository repo, IMapper mapper)
        {
            Repo = repo;
            Mapper = mapper;
        }

        // GET: api/Company/5
        public string Get(int id)
        {
            return "value";
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await Repo.GetAllContactsAsync();

                // mapping
                var mappedResult = Mapper.Map<IEnumerable<ContactModel>>(result);

                return Ok(mappedResult);
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }

        }


        //POST: api/Company
        [HttpPost]
        public HttpResponseMessage Contact(HttpRequestMessage Name)
        {
            var json = Name.Content.ReadAsStringAsync().Result;
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            Dictionary<string, object> contactObject = (Dictionary<string, object>)json_serializer.DeserializeObject(json);

            var companyId = (int)contactObject["CompanyId"];
            var contactTypeId = (int)contactObject["ContactTypeId"];
            var name = contactObject["Name"].ToString();
            var email = contactObject["Email"].ToString();
            var phone = contactObject["Phone"].ToString();
            var notes = contactObject["Notes"].ToString();
            var contact = new ContactModel();
            contact.CompanyId = companyId;
            contact.ContactTypeId = contactTypeId;
            contact.Email = email;
            contact.Name = name;
            contact.Notes = notes;
            contact.Phone = phone;

            SaveNewContact(contact);

            HttpResponseMessage message = new HttpResponseMessage();
            message.StatusCode = HttpStatusCode.OK;
            return message;
        }

        private void SaveNewCompany(CompanyModel model)
        {

            var entity = new Company()
            {
                CompanyId = model.CompanyId,
                Description = model.Description,
                Link = model.Link,
                Name = model.Name
            };

            using (var context = new MyJobRepoContext())
            {
                context.Companies.Add(entity);
                context.SaveChanges();
            }
        }

        private void SaveNewContact(ContactModel model)
        {

            var entity = new Contact()
            {
                ContactId = model.ContactId,
                CompanyId = model.CompanyId,
                ContactTypeId = model.ContactTypeId,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Notes = model.Notes
            };

            using (var context = new MyJobRepoContext())
            {
                context.Contacts.Add(entity);
                context.SaveChanges();
            }
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
