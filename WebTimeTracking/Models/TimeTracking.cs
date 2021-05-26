using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTimeTracking.Models
{
    public class TimeTracking
    {
        public Person Employee { get; set; }
        public List<TimeRecord> TimeRecords { get; set; }
        public double DayWorkingHours { get; set; }
    }
}
