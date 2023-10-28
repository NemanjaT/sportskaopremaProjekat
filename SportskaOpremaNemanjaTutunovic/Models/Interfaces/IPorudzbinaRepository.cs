using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskaOpremaNemanjaTutunovic.Models.Interfaces
{
    interface IPorudzbinaRepository
    {
        void DodajPorudzbinu(int id, int racun, List<KorpaBO> li);
        IEnumerable<PorudzbinaBO> GetByUserId(int id);
        IEnumerable<PorudzbinaBO> GetAllPorudzbine();
        PorudzbinaBO GetById(int idPor);
        void obrisiStavkeUPorudzbini(int idPor);
        void StornirajPorudzbinu(int idPor);
    }
}
