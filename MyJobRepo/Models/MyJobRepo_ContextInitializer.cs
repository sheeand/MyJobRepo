using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyJobRepo.Models
{
    public class MyJobRepo_ContextInitializer : DropCreateDatabaseAlways<MyJobRepoContext>
    {
        protected override void Seed(MyJobRepoContext context)
        {
            // Define an initial list
            var contactTypes = new List<ContactType>
            {
                new ContactType() {ContactTypeId = 1, Name = "Acquaintance"},
                new ContactType() {ContactTypeId = 1, Name = "Recruiter"},
                new ContactType() {ContactTypeId = 1, Name = "HR Representative"},
                new ContactType() {ContactTypeId = 1, Name = "Developer"},
                new ContactType() {ContactTypeId = 1, Name = "Hiring Manager"},
                new ContactType() {ContactTypeId = 1, Name = "Executive"}
            };

            // Pass the list to the database context
            contactTypes.ForEach(x => context.ContactTypes.Add(x));

            // Save the data to the database
            context.SaveChanges();



            base.Seed(context);
        }
    }
}