using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTimeTracking.Models
{
    public class Boss
    {
        public Person Employee { get; set; }
        public List<Person> Subordinates { get; set; }
    }
}
