using SportskaOpremaNemanjaTutunovic.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportskaOpremaNemanjaTutunovic.Models.EFRepository
{
    public class KategorijaRepository : IKategorijaRepository
    {
        private ProdavnicaPPPEntities prodavnicaEntities = new ProdavnicaPPPEntities();

        public void DodajKategoriju(KategorijaBO kategorija)
        {
            try
            {
                Kategorija kategorijaModel = new Kategorija();
                kategorijaModel.idKat = kategorija.idKat;
                kategorijaModel.NazivKategorije = kategorija.NazivKategorije;
                prodavnicaEntities.Kategorija.Add(kategorijaModel);
                prodavnicaEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Metod DodajKategoriju: " + ex.Message);

            }
        }

        public KategorijaBO GetById(int katId)
        {
            Kategorija kategorija = prodavnicaEntities.Kategorija.Single(t => t.idKat == katId);

            KategorijaBO kategorijaBO = new KategorijaBO
            {
                idKat = kategorija.idKat,
                NazivKategorije = kategorija.NazivKategorije,



            };
            return kategorijaBO;
        }

        public void UkloniKategoriju(KategorijaBO kategorija)
        {
            try
            {
                Kategorija kategorijaModel = prodavnicaEntities.Kategorija.Single(t => t.idKat == kategorija.idKat);
                prodavnicaEntities.Kategorija.Remove(kategorijaModel);
                prodavnicaEntities.SaveChanges();


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Greška kod brisanja Kategorije sa šifrom: " + kategorija.idKat + "\n" + ex.ToString());

            }
        }

        public IEnumerable<KategorijaBO> GetAllKategorije()
        {
            List<KategorijaBO> kategorije = new List<KategorijaBO>();

            foreach (Kategorija kategorija in prodavnicaEntities.Kategorija.ToList())
            {
                KategorijaBO kategorijaBO = new KategorijaBO();
                kategorijaBO.idKat = kategorija.idKat;
                kategorijaBO.NazivKategorije = kategorija.NazivKategorije;
               

                kategorije.Add(kategorijaBO);
            }
            return kategorije;
        }

        public bool postojiKategorija(int sifraKat)
        {
            Kategorija kategorija = prodavnicaEntities.Kategorija.Find(sifraKat);
            if (kategorija != null)
            {
                return true;
            }
            return false;
        }

        public void obrisiArtikleUKategoriji(int katId)
        {
            foreach (Artikal artikal in prodavnicaEntities.Artikal.Where(t => t.idKat == katId))
            {
                try
                {
                    
                    prodavnicaEntities.Artikal.Remove(artikal);
                    prodavnicaEntities.SaveChanges();


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Greška kod brisanja Artikla sa šifrom: " + artikal.ArtikalID + "\n" + ex.ToString());

                }
            }
        }
    }
}
