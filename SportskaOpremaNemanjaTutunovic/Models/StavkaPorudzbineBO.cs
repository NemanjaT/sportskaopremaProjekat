using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportskaOpremaNemanjaTutunovic.Models
{
    public class StavkaPorudzbineBO
    {
        public int StavkaID { get; set; }
        public int ArtikalID { get; set; }
        public string NazivArtikla { get; set; }

        public int Cena { get; set; }

        public int PorudzbinaID { get; set; }
    }
}