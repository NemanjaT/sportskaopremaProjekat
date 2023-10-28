using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportskaOpremaNemanjaTutunovic.Models
{
    public class KategorijaBO
    {

        [Key]
        [DisplayName("Sifra kategorije")]
        [Required(ErrorMessage = "Morate uneti sifru kategorije")]
        [Range(222, int.MaxValue, ErrorMessage = "Minimalna vrednost je 222")]
        public int idKat { get; set; }

        [DisplayName("Naziv kategorije")]
        [Required(ErrorMessage = "Morate uneti naziv kategorije")]
        public string NazivKategorije { get; set; }
    }
}