using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTimeTracking.Models
{
    public class Boss
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BossID { get; set; }
        [Required]
        public Person Employee { get; set; }
        public List<Person> Subordinates { get; set; }
    }
}
