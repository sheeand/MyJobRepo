using AutoMapper;
using MyJobRepo.Models;

namespace MyJobRepo.Data
{
    public class MyJobRepo_MappingProfile : Profile
    {
        public MyJobRepo_MappingProfile()
        {
            CreateMap<ContactType, ContactTypeModel>();
            CreateMap<Contact, ContactModel>();
            CreateMap<Company, CompanyModel>();
            CreateMap<Event, EventModel>();
            CreateMap<Posting, PostingModel>();
        }
    }
}