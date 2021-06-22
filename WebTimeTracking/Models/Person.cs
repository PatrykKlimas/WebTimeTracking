using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTimeTracking.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        [Required(ErrorMessage ="Prosze wpisać imię.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Prosze wpisać nazwisko.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Prosze wpisać email.")]
        [EmailAddress(ErrorMessage ="Prosze wpisać poprawny e-mail")]
        public string Emial { get; set; }
        [Required(ErrorMessage = "Prosze wpisać adres.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Wybierz miasto.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Prosze podać kod pocztwoy.")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Wybierz kraj.")]
        public string Country { get; set; }
    }
}
