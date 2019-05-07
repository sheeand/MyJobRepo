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
            Dictionary<string, object> postingObject =
                (Dictionary<string, object>) json_serializer.DeserializeObject(json);

            var posting = new PostingModel();
            posting.Title = postingObject["Title"].ToString();
            posting.CompanyName = postingObject["CompanyName"].ToString();
            posting.CompanyId = Convert.ToInt32(postingObject["CompanyId"]);
            posting.HRRepContactId = Convert.ToInt32(postingObject["HRRepContactId"]);
            posting.SrDevContactId = Convert.ToInt32(postingObject["SrDevContactId"]);
            posting.DevContactId = Convert.ToInt32(postingObject["DevContactId"]);
            posting.HiringMgrContactId = Convert.ToInt32(postingObject["HiringMgrContactId"]);
            posting.RecruiterContactId = Convert.ToInt32(postingObject["RecruiterContactId"]);
            posting.AcctManagerContactId = Convert.ToInt32(postingObject["AcctManagerContactId"]);
            posting.Link = postingObject["Link"].ToString();
            posting.Description = postingObject["Description"].ToString();
            posting.IsActive = (bool) postingObject["IsActive"];

            PostingService service = new PostingService();
            bool success = service.SaveNewPosting(posting);

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
    }
}
