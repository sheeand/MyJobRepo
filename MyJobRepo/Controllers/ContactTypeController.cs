using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using MyJobRepo.DataAccess;
using MyJobRepo.Models;

namespace MyJobRepo.Controllers
{
    [RoutePrefix("api/contacttype")]
    public class ContactTypeController : ApiController
    {
        private IRepository Repo;
        private IMapper Mapper;

        public ContactTypeController(IRepository repo, IMapper mapper)
        {
            Repo = repo;
            Mapper = mapper;
        }

        [Route()]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await Repo.GetAllContactTypesAsync();

                // mapping
                var mappedResult = Mapper.Map<IEnumerable<ContactTypeModel>>(result);
                if (result == null) return NotFound();

                return Ok(mappedResult);
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }
        }

        [Route("{ContactTypeId}")]
        public async Task<IHttpActionResult> Get(int contactTypeId)
        {
            try
            {
                var result = await Repo.GetContactTypeAsync(contactTypeId);

                // mapping
                var mappedResult = Mapper.Map<ContactTypeModel>(result);
                if (result == null) return NotFound();

                //return Ok(mappedResult);
                return Ok(Mapper.Map<ContactTypeModel>(result));
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }
        }
    }
}
