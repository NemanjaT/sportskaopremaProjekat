using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportskaOpremaNemanjaTutunovic.Models
{
    public class UserBO
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Morate uneti vasu email adresu")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Korisnicko ime")]
        [Required(ErrorMessage = "Morate uneti vase korisnicko ime")]
        public string Username { get; set; }

        [DisplayName("Lozinka")]
        [Required(ErrorMessage = "Morate uneti vasu lozinku")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}