using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTimeTracking.Models;

namespace WebTimeTracking.Data
{
    public class TrackingRepository : ITrackingRepository
    {
        private readonly TimeTrackingContext _ctx;
        public TrackingRepository(TimeTrackingContext ctx)
        {
            _ctx = ctx;
        }
        public void AddPerson(Person person)
        {
            _ctx.Persons.Add(person);
        }
        public Person GetPersonByID(int id)
        {
            return _ctx.Persons.Where(x => x.PersonId == id).FirstOrDefault();
        }

        public void SaveAll()
        {
            _ctx.SaveChanges();
        }
    }
}
