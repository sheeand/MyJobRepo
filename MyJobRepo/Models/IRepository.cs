using System.Linq;

namespace MyJobRepo.Models
{
    public interface IRepository
    {
        IQueryable<ContactType> GetAllContactTypes();
        ContactType GetContactType(int id);
        IQueryable<Contact> GetAllContacts();
        Contact GetContact(int id);
        IQueryable<Company> GetAllCompanies();
        Company GetCompany(int id);
        IQueryable<Posting> GetAllPostings();
        Posting GetPosting(int id);
        IQueryable<PostingContact> GetAllPostingContacts();
        PostingContact GetPostingContact(int id);
        IQueryable<Event> GetAllEvents();
        Event GetEvents(int id);
    }
}
