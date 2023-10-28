using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportskaOpremaNemanjaTutunovic.Models
{
    public class ArtikalBO
    {
        [Key]
        [DisplayName("Sifra Artikla")]
        [Required(ErrorMessage = "Morate uneti sifru artikla")]
        [Range(100,int.MaxValue,ErrorMessage = "Minimalna vrednost je 100")]
        public int ArtikalID { get; set; }

        [DisplayName("Naziv artikla")]
        [Required(ErrorMessage = "Morate uneti naziv artikla.")]
        public string NazivArtikla { get; set; }

        [Required(ErrorMessage = "Morate uneti cenu")]
        [Range(10, int.MaxValue, ErrorMessage = "Minimalna vrednost za cenu je 10")]
        public int Cena { get; set; }

        public KategorijaBO Kategorija { get; set; }
    }
}