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
    public class CompanyController : ApiController
    {
        private IRepository Repo;
        private IMapper Mapper;

        public CompanyController(IRepository repo, IMapper mapper)
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
                var result = await Repo.GetAllCompaniesAsync();

                // mapping
                var mappedResult = Mapper.Map<IEnumerable<CompanyModel>>(result);

                return Ok(mappedResult);
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }

        }


        //POST: api/Company
        [HttpPost]
        public HttpResponseMessage Company(HttpRequestMessage Name)
        {
            var json = Name.Content.ReadAsStringAsync().Result;
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            //var company = json_serializer.DeserializeObject(json);
            //Dictionary<string, object> companyObject;
            Dictionary<string, object> companyObject = (Dictionary<string, object>)json_serializer.DeserializeObject(json);

            var name = companyObject["Name"].ToString();
            var link = companyObject["Link"].ToString();
            var desc = companyObject["Description"].ToString();
            var company = new CompanyModel();
            company.Name = name;
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
                Name = model.Name
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
