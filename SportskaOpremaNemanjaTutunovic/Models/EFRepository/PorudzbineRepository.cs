using SportskaOpremaNemanjaTutunovic.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportskaOpremaNemanjaTutunovic.Models.EFRepository
{
    public class PorudzbineRepository : IPorudzbinaRepository
    {
        private ProdavnicaPPPEntities prodavnicaEntities = new ProdavnicaPPPEntities();

        public void DodajPorudzbinu(int id, int racun, List<KorpaBO> li)
        {
            Porudzbina porudzbinaModel = new Porudzbina();

            porudzbinaModel.IDKorisnika = id;
            porudzbinaModel.vreme = System.DateTime.Now;
            porudzbinaModel.cena = racun;
            prodavnicaEntities.Porudzbina.Add(porudzbinaModel);
            prodavnicaEntities.SaveChanges();

            foreach (var item in li)
            {
                StavkaPorudzbine stv = new StavkaPorudzbine();
                stv.ArtikalID = item.ArtikalID;
                stv.PorudzbinaID = porudzbinaModel.PorudzbinaID;
                stv.NazivArtikla = item.NazivArtikla;
                stv.Cena = item.UkupnaCena;

                prodavnicaEntities.StavkaPorudzbine.Add(stv);
                prodavnicaEntities.SaveChanges();

            }
        }

        public void DodajStavkePorudzbina(List<KorpaBO> li)
        {
            foreach (var item in li)
            {
                StavkaPorudzbine stv = new StavkaPorudzbine();
                stv.ArtikalID = item.ArtikalID;

            }
        }

        public IEnumerable<PorudzbinaBO> GetByUserId(int id)
        {
            List<PorudzbinaBO> porudzbine = new List<PorudzbinaBO>();
            foreach (Porudzbina porudzbinaModel in prodavnicaEntities.Porudzbina.Where(t => t.IDKorisnika == id))
            {
                PorudzbinaBO porudzbinaBO = new PorudzbinaBO();
                porudzbinaBO.PorudzbinaID = porudzbinaModel.PorudzbinaID;
                porudzbinaBO.Cena = porudzbinaModel.cena;
                porudzbinaBO.Vreme = porudzbinaModel.vreme;

                porudzbine.Add(porudzbinaBO);
            }
            return porudzbine;
        }

        public IEnumerable<PorudzbinaBO> GetAllPorudzbine()
        {
            List<PorudzbinaBO> porudzbine = new List<PorudzbinaBO>();

            foreach (Porudzbina porudzbina in prodavnicaEntities.Porudzbina.ToList())
            {
                PorudzbinaBO porudzbinaBO = new PorudzbinaBO();
                porudzbinaBO.PorudzbinaID = porudzbina.PorudzbinaID;
                porudzbinaBO.Cena = porudzbina.cena;
                porudzbinaBO.Vreme = porudzbina.vreme;
                porudzbinaBO.KorisnikID = porudzbina.IDKorisnika;

                porudzbine.Add(porudzbinaBO);
            }
            return porudzbine;
        }

        public void StornirajPorudzbinu(int idPor)
        {
            try
            {
                Porudzbina porudzbina = prodavnicaEntities.Porudzbina.Single(t => t.PorudzbinaID == idPor);
                prodavnicaEntities.Porudzbina.Remove(porudzbina);
                prodavnicaEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Greška kod brisanja Porudzbine " + ex.ToString());

            }

        }

        public PorudzbinaBO GetById(int idPor)
        {
            Porudzbina porudzbina = prodavnicaEntities.Porudzbina.Single(t => t.PorudzbinaID == idPor);
            PorudzbinaBO porudzbinaBO = new PorudzbinaBO
            {
                PorudzbinaID = porudzbina.PorudzbinaID,
                Cena = porudzbina.cena,
                Vreme = porudzbina.vreme,
                KorisnikID = porudzbina.IDKorisnika



            };
            return porudzbinaBO;
        }

        public void obrisiStavkeUPorudzbini(int idPor)
        {
            foreach (StavkaPorudzbine stv in prodavnicaEntities.StavkaPorudzbine.Where(t => t.PorudzbinaID == idPor))
            {
                try
                {

                    prodavnicaEntities.StavkaPorudzbine.Remove(stv);
                    prodavnicaEntities.SaveChanges();


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Greška kod brisanja Stavke sa šifrom: " + stv.StavkaID + "\n" + ex.ToString());

                }
            }
        }
    }
}