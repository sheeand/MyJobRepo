using System.Linq;

namespace MyJobRepo.Models
{
    public interface IRepository
    {
        IQueryable<ContactType> GetAllContactTypes();
        ContactType GetContactTypeById(int id);
        IQueryable<Contact> GetAllContacts();
        Contact GetContactById(int id);
        IQueryable<Company> GetAllCompanies();
        Company GetCompanyById(int id);
        IQueryable<Posting> GetAllPostings();
        Posting GetPostingById(int id);
        IQueryable<PostingContact> GetAllPostingContacts();
        PostingContact GetPostingContactById(int id);
        IQueryable<Event> GetAllEvents();
        Event GetEventsById(int id);
    }
}
