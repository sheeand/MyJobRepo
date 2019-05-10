using AutoMapper;
using MyJobRepo.Data;
using MyJobRepo.Models;

namespace MyJobRepo.Mapping
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