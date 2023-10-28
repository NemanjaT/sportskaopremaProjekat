using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskaOpremaNemanjaTutunovic.Models.Interfaces
{
    interface IKategorijaRepository
    {
        void DodajKategoriju(KategorijaBO kategorija);
        void UkloniKategoriju(KategorijaBO kategorija);

        KategorijaBO GetById(int katId);

       IEnumerable<KategorijaBO> GetAllKategorije();

        bool postojiKategorija(int sifraKat);

        void obrisiArtikleUKategoriji(int katId);
    }
}
