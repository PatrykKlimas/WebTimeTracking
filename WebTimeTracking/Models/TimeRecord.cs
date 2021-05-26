using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTimeTracking.Models
{
    public class TimeRecord
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeRocordID { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
    }
}
