using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportskaOpremaNemanjaTutunovic.Models
{
    public class PorudzbinaBO
    {
        public int PorudzbinaID { get; set; }
        public int Cena { get; set; }
        public DateTime Vreme { get; set; }

        public int KorisnikID { get; set; }
    }
}