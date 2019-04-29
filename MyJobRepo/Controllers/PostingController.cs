using AutoMapper;
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

                    //return Ok(mappedResult);
                    return Ok(Mapper.Map<PostingModel>(result));
                }
                catch //(Exception e)
                {
                    return InternalServerError();
                }
            }

            //POST: api/Company
            [Route()]
            [HttpPost]
            public HttpResponseMessage Posting(HttpRequestMessage Data)
            {
                var json = Data.Content.ReadAsStringAsync().Result;
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                Dictionary<string, object> postingObject = (Dictionary<string, object>)json_serializer.DeserializeObject(json);

                var postingId = (int)postingObject["PostingId"];
                var companyId = (int)postingObject["CompanyId"];
                var title = postingObject["Title"].ToString();
                var link = postingObject["Link"].ToString();
                var description = postingObject["Description"].ToString();
                var isActive = (bool)postingObject["IsActive"];
                var posting = new PostingModel();
                posting.CompanyId = companyId;
                posting.PostingId = postingId;
                posting.Title = title;
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

                var entity = new Posting()
                {
                    PostingId = model.PostingId,
                    CompanyId = model.CompanyId,
                    Title = model.Title,
                    Link = model.Link,
                    Description = model.Description,
                    IsActive = model.IsActive
                };

                using (var context = new MyJobRepoContext())
                {
                    context.Postings.Add(entity);
                    context.SaveChanges();
                }
            }
        }
    }
