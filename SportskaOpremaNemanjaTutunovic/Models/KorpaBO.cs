using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportskaOpremaNemanjaTutunovic.Models
{
    public class KorpaBO
    {
        
        public int ArtikalID { get; set; }
        public string NazivArtikla { get; set; }

        public int Cena { get; set; }

        public int Kolicina { get; set; }

        public int UkupnaCena { get; set; }

        
    }
}