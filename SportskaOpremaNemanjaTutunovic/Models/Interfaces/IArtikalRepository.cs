using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskaOpremaNemanjaTutunovic.Models.Interfaces
{
    interface IArtikalRepository
    {
        IEnumerable<ArtikalBO> GetAllArtikli();
        ArtikalBO GetById(int ArtikalID);

        IEnumerable<ArtikalBO> GetAllByKategorijaId(int katId);

        void DodajArtikal(ArtikalBO artikal);
        void ObrisiArtikal(int ArtikalID);

        void IzmeniArtikal(ArtikalBO artikal);

        IEnumerable<KategorijaBO> GetAllKategorije();

        KorpaBO DodajKorpa( string kol, int id);

        bool postojiArtikal(int sifraArtikla);
        void obrisiStavkeUPorudzbini(int idArt);
    }
}
