using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using MyJobRepo.Services.Repository;
using MyJobRepo.Models;
using MyJobRepo.Services;

namespace MyJobRepo.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Host = "localhost:56097";

            var contactTypeService = new ContactTypeService();
            var contactTypes = contactTypeService.GetAllContactTypes();
            var mappedContactTypes = Mapper.Map<IQueryable<ContactTypeModel>>(contactTypes);

            var contactService = new ContactService();
            var contacts = contactService.GetAllContacts();
            var mappedContacts = Mapper.Map<IQueryable<ContactModel>>(contacts);

            var companyService = new CompanyService();
            var companies = companyService.GetAllCompanies();
            var mappedCompanies = Mapper.Map<IQueryable<CompanyModel>>(companies);

            var postingService = new PostingService();
            var postings = postingService.GetAllPostings();
            var mappedPostings = Mapper.Map<IQueryable<PostingModel>>(postings);

            var eventService = new EventService();
            var events = eventService.GetAllEvents();
            var mappedEvents = Mapper.Map<IQueryable<EventModel>>(events);

            var resources = new MyJobRepo_ResourcesModel()
            {
                ContactTypeModels = mappedContactTypes,
                ContactModels = mappedContacts,
                CompanyModels = mappedCompanies,
                EventModels = mappedEvents,
                PostingModels = mappedPostings
            };

            return View(resources);
        }
    }
}
