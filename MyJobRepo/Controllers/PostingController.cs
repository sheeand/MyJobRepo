using AutoMapper;
using MyJobRepo.DataAccess;
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
        [RoutePrefix("api/posting")]
        public class PostingController : ApiController
        {
            private IRepository Repo;
            private IMapper Mapper;

            public PostingController(IRepository repo, IMapper mapper)
            {
                Repo = repo;
                Mapper = mapper;
            }

            [Route("all")]
            public async Task<IHttpActionResult> Get()
            {
                try
                {
                    var result = await Repo.GetAllPostingsAsync();

                    // mapping
                    var mappedResult = Mapper.Map<IEnumerable<PostingModel>>(result);
                    if (result == null) return NotFound();

                return Ok(mappedResult);
                }
                catch //(Exception e)
                {
                    return InternalServerError();
                }

            }

        [Route("ById/{PostingId}")]
            public async Task<IHttpActionResult> Get(int postingId)
            {
                try
                {
                    var result = await Repo.GetPostingAsync(postingId);

                    // mapping
                    var mappedResult = Mapper.Map<PostingModel>(result);
                    if (result == null) return NotFound();

                //return Ok(mappedResult);
                return Ok(Mapper.Map<PostingModel>(result));
                }
                catch //(Exception e)
                {
                    return InternalServerError();
                }
            }

            [Route()]
            [HttpPost]
            public HttpResponseMessage Posting(HttpRequestMessage Data)
            {
                var json = Data.Content.ReadAsStringAsync().Result;
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                Dictionary<string, object> postingObject = (Dictionary<string, object>)json_serializer.DeserializeObject(json);

                var title = postingObject["Title"].ToString();
                var companyName = postingObject["CompanyName"].ToString();
                var companyId = Convert.ToInt32(postingObject["CompanyId"]);
                var hrRepContactId = Convert.ToInt32(postingObject["HRRepContactId"]);
                var srDevContactId = Convert.ToInt32(postingObject["SrDevContactId"]);
                var devContactId = Convert.ToInt32(postingObject["DevContactId"]);
                var hiringMgrContactId = Convert.ToInt32(postingObject["HiringMgrContactId"]);
                var recruiterContactId = Convert.ToInt32(postingObject["RecruiterContactId"]);
                var acctManagerContactId = Convert.ToInt32(postingObject["AcctManagerContactId"]);
                var link = postingObject["Link"].ToString();
                var description = postingObject["Description"].ToString();
                var isActive = (bool)postingObject["IsActive"];

                var posting = new PostingModel();
                posting.Title = title;
                posting.CompanyName = companyName;
                posting.CompanyId = companyId;
                posting.HRRepContactId = hrRepContactId;
                posting.SrDevContactId = srDevContactId;
                posting.DevContactId = devContactId;
                posting.HiringMgrContactId = hiringMgrContactId;
                posting.RecruiterContactId = recruiterContactId;
                posting.AcctManagerContactId = acctManagerContactId;
                posting.Link = link;
                posting.Description = description;
                posting.IsActive = isActive;

                SaveNewPosting(posting);

                HttpResponseMessage message = new HttpResponseMessage();
                message.StatusCode = HttpStatusCode.OK;
                return message;
            }

        private void SaveNewPosting(PostingModel model)
        {
            var postingEntity = new Posting()
            {
                CompanyName = model.CompanyName,
                Title = model.Title,
                Link = model.Link,
                Description = model.Description,
                IsActive = model.IsActive,
                HRRepContactId = model.HRRepContactId,
                SrDevContactId = model.SrDevContactId,
                DevContactId = model.DevContactId,
                HiringMgrContactId = model.HiringMgrContactId,
                RecruiterContactId = model.RecruiterContactId,
                AcctManagerContactId = model.AcctManagerContactId
            };

            using (var context = new MyJobRepo_DataContext())
            {
                context.Postings.Add(postingEntity);
                context.SaveChanges();
            }
        }
    }
}
