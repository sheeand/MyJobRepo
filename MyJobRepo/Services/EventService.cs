using MyJobRepo.DataAccess;
using MyJobRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Services
{
    public class EventService
    {
        public bool SaveNewEvent(EventModel model)
        {
            var entity = new Event()
            {
                EntryDateTime = model.EntryDateTime,
                CompanyId = model.CompanyId,
                PostingId = model.PostingId,
                IsActionRequired = model.IsActionRequired,
                Action = model.Action
            };

            using (var context = new MyJobRepo_DataContext())
            {
                try
                {
                    context.Events.Add(entity);
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