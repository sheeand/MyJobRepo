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
    [RoutePrefix("api/event")]
    public class EventController : ApiController
    {
        private IRepository Repo;
        private IMapper Mapper;

        public EventController(IRepository repo, IMapper mapper)
        {
            Repo = repo;
            Mapper = mapper;
        }

        [Route("all")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await Repo.GetAllEventsAsync();

                // mapping
                var mappedResult = Mapper.Map<IEnumerable<EventModel>>(result);
                if (result == null) return NotFound();

                return Ok(mappedResult);
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }

        }

        [HttpGet]
        [Route("ByCompanyId/{CompanyId}")]
        public async Task<IHttpActionResult> EventList(int companyId)
        {
            try
            {
                var result = await Repo.GetAllEventsByCompanyIdAsync(companyId);

                var mappedResult = Mapper.Map<IEnumerable<EventModel>>(result);
                if (result == null) return NotFound();

                return Ok(mappedResult);
            }
            catch //(Exception e)
            {
                return InternalServerError();
            }

        }


        [Route("{EventId}")]
        public async Task<IHttpActionResult> Get(int eventId)
        {
            try
            {
                var result = await Repo.GetEventByIdAsync(eventId);

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

        [Route()]
        [HttpPost]
        public HttpResponseMessage Event(HttpRequestMessage request)
        {
            var json = request.Content.ReadAsStringAsync().Result;
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            Dictionary<string, object> eventObject = (Dictionary<string, object>)json_serializer.DeserializeObject(json);

            var entryDateTime = Convert.ToDateTime(eventObject["EntryDateTime"]);
            var companyId = Convert.ToInt32(eventObject["CompanyId"]);
            var requiresAction = Convert.ToBoolean(eventObject["RequiresAction"]);
            var eventModel = new EventModel();
            eventModel.EntryDateTime = entryDateTime;
            eventModel.CompanyId = companyId;
            eventModel.IsActionRequired = requiresAction;

            SaveNewEvent(eventModel);

            HttpResponseMessage message = new HttpResponseMessage();
            message.StatusCode = HttpStatusCode.OK;
            return message;
        }

        private void SaveNewEvent(EventModel model)
        {

            var entity = new Event()
            {
                EntryDateTime = model.EntryDateTime,
                PostingId = model.CompanyId,
                IsActionRequired = model.IsActionRequired
            };

            using (var context = new MyJobRepoContext())
            {
                context.Events.Add(entity);
                context.SaveChanges();
            }
        }
    }
}
