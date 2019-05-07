using System.Data.Entity;

namespace MyJobRepo.DataAccess
{
    public class MyJobRepo_DataContext : DbContext
    {
        //internal static readonly MyJobRepo_DataContext dbContext;

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public MyJobRepo_DataContext() : base("name=MyJobRepo_DataContext")
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Posting> Postings { get; set; }
    }
}
