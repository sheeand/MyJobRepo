using MyJobRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyJobRepo.Controllers
{
    public class ContactTypeController : ApiController
    {
        private IRepository Repo;

        public ContactTypeController(IRepository repo)
        {
            Repo = repo;
        }

        public IQueryable<ContactType> Get()
        {
            return Repo.GetAllContactTypes();
        }

        public ContactType Get(int id)
        {
            return Repo.GetContactType(id);
        }
    }
}
