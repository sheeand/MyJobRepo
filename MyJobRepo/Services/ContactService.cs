using System;
using MyJobRepo.DataAccess;
using MyJobRepo.Models;

namespace MyJobRepo.Services
{
    public class ContactService
    {
        public bool SaveNewContact(ContactModel model)
        {
            var entity = new Contact()
            {
                ContactId = model.ContactId,
                CompanyId = model.CompanyId,
                ContactTypeId = model.ContactTypeId,
                ContactName = model.ContactName,
                Email = model.Email,
                Phone = model.Phone,
                Notes = model.Notes
            };

            using (var context = new MyJobRepo_DataContext())
            {
                try
                {
                    context.Contacts.Add(entity);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }

    }
}