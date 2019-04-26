using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Newtonsoft.Json.Linq;

namespace MyJobRepo.Data
{
    public class Repository : IRepository
    {
        //private readonly EFContextProvider<MyJobRepoContext> ContextProvider = new EFContextProvider<MyJobRepoContext>();

        //public string MetaData => ContextProvider.Metadata();


        // End points 

        //public SaveResult SaveChanges(JObject saveBundle)
        //{
        //    return ContextProvider.SaveChanges(saveBundle);
        //}

        //public IQueryable<ContactType> ContactTypes()
        //{
        //    return ContextProvider.Context.ContactTypes;
        //}

        //public IQueryable<Contact> Contacts()
        //{
        //    return ContextProvider.Context.Contacts;
        //}

        //public IQueryable<Company> Companies()
        //{
        //    return ContextProvider.Context.Companies;
        //}

        //public IQueryable<Posting> Postings()
        //{
        //    return ContextProvider.Context.Postings;
        //}

        //public IQueryable<PostingContact> PostingContacts()
        //{
        //    return ContextProvider.Context.PostingContacts;
        //}

        //public IQueryable<Event> Events()
        //{
        //    return ContextProvider.Context.Events; 
        //}

        private MyJobRepoContext dbContext;

        public Repository(MyJobRepoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public IQueryable<ContactType> GetAllContactTypes()
        //{
        //    return dbContext.ContactTypes;
        //}

        public async Task<ContactType[]> GetAllContactTypesAsync()
        {
            IQueryable<ContactType> query = dbContext.ContactTypes;
            return await query.ToArrayAsync();
        }

        public async Task<Company[]> GetAllCompaniesAsync()
        {
            IQueryable<Company> query = dbContext.Companies;
            return await query.ToArrayAsync();
        }

        //public ContactType GetContactType(int id)
        //{
        //    return dbContext.ContactTypes(id);
        //}

        public IQueryable<Contact> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Company> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Posting> GetAllPostings()
        {
            throw new NotImplementedException();
        }

        public Posting GetPosting(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PostingContact> GetAllPostingContacts()
        {
            throw new NotImplementedException();
        }

        public PostingContact GetPostingContact(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public Event GetEvents(int id)
        {
            throw new NotImplementedException();
        }

        public ContactType GetContactType(int id)
        {
            throw new NotImplementedException();
        }
    }
}