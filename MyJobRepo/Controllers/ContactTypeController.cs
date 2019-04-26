using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using MyJobRepo.Data;
using MyJobRepo.Models;

namespace MyJobRepo.Controllers
{
    public class ContactTypeController : ApiController
    {
        private IRepository Repo;
        private IMapper Mapper;

        public ContactTypeController(IRepository repo, IMapper mapper)
        {
            Repo = repo;
            Mapper = mapper;
        }

        //public IQueryable<ContactType> Get()
        //{
        //    return Repo.GetAllContactTypes();
        //}

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await Repo.GetAllContactTypesAsync();

                // mapping
                var mappedResult = Mapper.Map<IEnumerable<ContactTypeModel>>(result);

                return Ok(mappedResult);
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }

        }

        public ContactType Get(int id)
        {
            return Repo.GetContactType(id);
        }
    }
}
