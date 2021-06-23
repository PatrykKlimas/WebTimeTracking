using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTimeTracking.Models;

namespace WebTimeTracking.Data
{
    public interface ITrackingRepository
    {
        public void AddPerson(Person person);
        public void SaveAll();
    }
}
