using System.Linq;
using System.Threading.Tasks;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace MyJobRepo.DataAccess
{
    public interface IRepository
    {
        Task<ContactType> GetContactTypeAsync(int contactTypeId);
        Task<ContactType[]> GetAllContactTypesAsync();
        Task<Contact> GetContactAsync(int contactId);
        Task<Contact[]> GetAllContactsAsync();
        Task<Contact[]> GetContactsByContactTypeAsync(string contactType);
        Task<Company> GetCompanyAsync(int companyId);
        Task<Company[]> GetAllCompaniesAsync();
        Task<Posting> GetPostingAsync(int postingId);
        Task<Posting[]> GetAllPostingsAsync();
        Task<Event[]> GetAllEventsByCompanyIdAsync(int companyId);
        Task<Event[]> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int eventId);
        Task<Company[]> GetCompaniesAsync(bool isEmployer);
    }
}
