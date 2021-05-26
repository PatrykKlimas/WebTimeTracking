using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTimeTracking.Models
{
    public class TimeTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeTrackingID { get; set; }
        public Person Employee { get; set; }
        public List<TimeRecord> TimeRecords { get; set; }
        public double DayWorkingHours { get; set; }
    }
}
