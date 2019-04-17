using Breeze.WebApi2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MyJobRepo.Models;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace MyJobRepo.Controllers
{
    // Instead of having a Controller for type
    // this is a single Controller for the model we want to expose
    // with only one to three Get methods for each type

    [BreezeController]
    public class BreezeController : ApiController
    {
        private readonly IRepository Repo;

        public BreezeController(IRepository repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public string Metadata()
        {
            return Repo.MetaData;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return Repo.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<ContactType> ContactTypes()
        {
            return Repo.ContactTypes();
        }

        [HttpGet]
        public IQueryable<Contact> Contacts()
        {
            return Repo.Contacts();
        }

        [HttpGet]
        public IQueryable<Company> Companies()
        {
            return Repo.Companies();
        }

        [HttpGet]
        public IQueryable<Posting> Postings()
        {
            return Repo.Postings();
        }

        [HttpGet]
        public IQueryable<PostingContact> PostingContacts()
        {
            return Repo.PostingContacts();
        }

        [HttpGet]
        public IQueryable<Event> Events()
        {
            return Repo.Events();
        }

    }
}