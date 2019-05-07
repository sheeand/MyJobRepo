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
        [Route("ByPosting/{CompanyId}")]
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

            var eventModel = new EventModel();
            eventModel.PostingId = Convert.ToInt32(eventObject["PostingId"]);
            eventModel.EntryDateTime = Convert.ToDateTime(eventObject["EntryDateTime"]);
            eventModel.CompanyId = Convert.ToInt32(eventObject["CompanyId"]);
            eventModel.IsActionRequired = Convert.ToBoolean(eventObject["IsActionRequired"]);
            eventModel.Action = eventObject["Action"].ToString();

            EventService service = new EventService();
            bool success = service.SaveNewEvent(eventModel);

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
