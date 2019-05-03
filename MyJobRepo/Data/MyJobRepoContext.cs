using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyJobRepo.Data
{
    public class MyJobRepoContext : DbContext
    {
        //internal static readonly MyJobRepoContext dbContext;

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public MyJobRepoContext() : base("name=MyJobRepoContext")
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Posting> Postings { get; set; }
        public DbSet<PostingContact> PostingContacts { get; set; }
    }
}
