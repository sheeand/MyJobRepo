using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Script.Serialization;
using AutoMapper;
using MyJobRepo.Data;
using MyJobRepo.Models;

namespace MyJobRepo.Controllers
{
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        private IRepository Repo;
        private IMapper Mapper;

        public CompanyController(IRepository repo, IMapper mapper)
        {
            Repo = repo;
            Mapper = mapper;
        }

        [Route("All")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await Repo.GetAllCompaniesAsync();

                // mapping
                var mappedResult = Mapper.Map<IEnumerable<CompanyModel>>(result);
                if (result == null) return NotFound();

                return Ok(mappedResult);
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }

        }

        [HttpGet]
        [Route("Employers")]
        public async Task<IHttpActionResult> Employers()
        {
            try
            {
                var result = await Repo.GetCompaniesAsync(true);

                // mapping
                var mappedResult = Mapper.Map<IEnumerable<CompanyModel>>(result);
                if (result == null) return NotFound();

                return Ok(mappedResult);
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }

        }

        [HttpGet]
        [Route("Recruiters")]
        public async Task<IHttpActionResult> Recruiters()
        {
            try
            {
                var result = await Repo.GetCompaniesAsync(false);

                // mapping
                var mappedResult = Mapper.Map<IEnumerable<CompanyModel>>(result);
                if (result == null) return NotFound();

                return Ok(mappedResult);
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }

        }

        [Route("{CompanyId}")]
        public async Task<IHttpActionResult> Get(int companyId)
        {
            try
            {
                var result = await Repo.GetCompanyAsync(companyId);

                // mapping
                var mappedResult = Mapper.Map<CompanyModel>(result);
                if (result == null) return NotFound();

                //return Ok(mappedResult);
                return Ok(Mapper.Map<CompanyModel>(result));
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }
        }

        //POST: api/Company
        [Route()]
        [HttpPost]
        public HttpResponseMessage Company(HttpRequestMessage request)
        {
            var json = request.Content.ReadAsStringAsync().Result;
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            Dictionary<string, object> companyObject = (Dictionary<string, object>)json_serializer.DeserializeObject(json);

            var companyName = companyObject["CompanyName"].ToString();
            var link = companyObject["Link"].ToString();
            var isEmployer = Convert.ToBoolean(companyObject["IsEmployer"]);
            var desc = companyObject["Description"].ToString();
            var company = new CompanyModel();
            company.CompanyName = companyName;
            company.IsEmployer = isEmployer;
            company.Link = link;
            company.Description = desc;

            SaveNewCompany(company);

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
                CompanyName = model.CompanyName,
                IsEmployer = model.IsEmployer
            };

            using (var context = new MyJobRepoContext())
            {
                context.Companies.Add(entity);
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
