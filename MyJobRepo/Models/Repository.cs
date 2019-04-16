using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Models
{
    public class Repository : IRepository
    {
        private MyJobRepoContext db;

        public Repository(MyJobRepoContext db)
        {
            this.db = db;
        }

        // End points 

        public IQueryable<ContactType> GetAllContactTypes()
        {
            return db.ContactTypes;
        }

        public ContactType GetContactType(int id)
        {
            return db.ContactTypes.Find(id);
        }


        public IQueryable<Contact> GetAllContacts()
        {
            return db.Contacts;
        }

        public Contact GetContact(int id)
        {
            return db.Contacts.Find(id);
        }


        public IQueryable<Company> GetAllCompanies()
        {
            return db.Companies;
        }

        public Company GetCompany(int id)
        {
            return db.Companies.Find(id);
        }


        public IQueryable<Posting> GetAllPostings()
        {
            return db.Postings;
        }

        public Posting GetPosting(int id)
        {
            return db.Postings.Find(id);
        }


        public IQueryable<PostingContact> GetAllPostingContacts()
        {
            return db.PostingContacts;
        }

        public PostingContact GetPostingContact(int id)
        {
            return db.PostingContacts.Find(id);
        }


        public IQueryable<Event> GetAllEvents()
        {
            return db.Events;
        }

        public Event GetEvents(int id)
        {
            return db.Events.Find(id);
        }
    }
}