using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Newtonsoft.Json.Linq;

namespace MyJobRepo.Models
{
    public class Repository : IRepository
    {
        private readonly EFContextProvider<MyJobRepoContext> ContextProvider = new EFContextProvider<MyJobRepoContext>();

        public string MetaData => ContextProvider.Metadata();


        // End points 

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return ContextProvider.SaveChanges(saveBundle);
        }

        public IQueryable<ContactType> ContactTypes()
        {
            return ContextProvider.Context.ContactTypes;
        }

        public IQueryable<Contact> Contacts()
        {
            return ContextProvider.Context.Contacts;
        }

        public IQueryable<Company> Companies()
        {
            return ContextProvider.Context.Companies;
        }

        public IQueryable<Posting> Postings()
        {
            return ContextProvider.Context.Postings;
        }

        public IQueryable<PostingContact> PostingContacts()
        {
            return ContextProvider.Context.PostingContacts;
        }

        public IQueryable<Event> Events()
        {
            return ContextProvider.Context.Events;
        }
    }
}