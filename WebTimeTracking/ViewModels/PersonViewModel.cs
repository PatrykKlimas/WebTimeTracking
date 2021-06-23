using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTimeTracking.ViewModels
{
    public class PersonViewModel
    {

        [Required(ErrorMessage = "Prosze wpisać imię.")]
        [MinLength(3,ErrorMessage ="Imie powinno zawierac conajmniej 3 znaki.")]
        [MaxLength(50, ErrorMessage = "Imie nie powinno zawierac wiecej niz 50 znaków.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Prosze wpisać nazwisko.")]
        [MinLength(3, ErrorMessage = "Nazwisko powinno zawierac conajmniej 3 znaki.")]
        [MaxLength(50, ErrorMessage = "Nazwisko nie powinno zawierac wiecej niz 50 znaków.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Prosze wpisać email.")]
        [EmailAddress(ErrorMessage = "Prosze wpisać poprawny e-mail")]
        public string Emial { get; set; }

        [Required(ErrorMessage ="Prosze podać hasło")]
        [MinLength(6, ErrorMessage ="Hasło musi zawierać conajmniej 6 znaków.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Prosze potwierdzić hasło")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Prosze wpisać adres.")]
        [MinLength(10, ErrorMessage = "Adres powinno zawierac conajmniej 10 znaki.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Wybierz miasto.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Prosze podać kod pocztwoy.")]
        [MinLength(6, ErrorMessage = "Kod pocztowy powinien sklada sie z 6 znaków.")]
        [MaxLength(6, ErrorMessage = "Kod pocztowy powinien sklada sie z 6 znaków.")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Wybierz kraj.")]
        public string Country { get; set; }
    }
}
