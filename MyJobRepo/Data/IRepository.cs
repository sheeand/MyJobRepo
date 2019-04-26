using System.Linq;
using System.Threading.Tasks;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace MyJobRepo.Data
{
    public interface IRepository
    {
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
        Task<ContactType[]> GetAllContactTypesAsync();
        Event GetEvents(int id);
        Task<Contact[]> GetAllContactsAsync();
        Task<Company[]> GetAllCompaniesAsync();
    }
}
