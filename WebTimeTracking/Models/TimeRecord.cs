using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTimeTracking.Models
{
    public class TimeRecord
    {
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
    }
}
