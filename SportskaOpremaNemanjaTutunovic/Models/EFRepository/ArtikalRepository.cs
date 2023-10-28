using SportskaOpremaNemanjaTutunovic.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SportskaOpremaNemanjaTutunovic.Models.EFRepository
{
    public class ArtikalRepository : IArtikalRepository
    {
        private ProdavnicaPPPEntities prodavnicaEntities = new ProdavnicaPPPEntities();



        public void DodajArtikal(ArtikalBO artikal)
        {
            Artikal artikalModel = new Artikal();
            artikalModel.ArtikalID = artikal.ArtikalID;
            artikalModel.NazivArtikla = artikal.NazivArtikla;
            artikalModel.Cena = artikal.Cena;
            artikalModel.idKat = artikal.Kategorija.idKat;
            prodavnicaEntities.Artikal.Add(artikalModel);
            prodavnicaEntities.SaveChanges();
        }

        public IEnumerable<ArtikalBO> GetAllArtikli()
        {
            List<ArtikalBO> artikli = new List<ArtikalBO>();

            foreach (Artikal artikal in prodavnicaEntities.Artikal.ToList())
            {
                ArtikalBO artikalBO = new ArtikalBO();
                artikalBO.ArtikalID = artikal.ArtikalID;
                artikalBO.NazivArtikla = artikal.NazivArtikla;
                artikalBO.Cena = artikal.Cena;
                Kategorija k = prodavnicaEntities.Kategorija.SingleOrDefault(t => t.idKat == artikal.idKat);
                artikalBO.Kategorija = new KategorijaBO()
                {
                    idKat = k.idKat,
                    NazivKategorije = k.NazivKategorije
                };

                artikli.Add(artikalBO);
            }
            return artikli;
        }

        public IEnumerable<ArtikalBO> GetAllByKategorijaId(int katId)
        {
            List<ArtikalBO> artikli = new List<ArtikalBO>();

            foreach (Artikal artikal in prodavnicaEntities.Artikal.Where(t => t.idKat == katId).ToList())
            {
                ArtikalBO artikalBO = new ArtikalBO();
                artikalBO.ArtikalID = artikal.ArtikalID;
                artikalBO.NazivArtikla = artikal.NazivArtikla;
                artikalBO.Cena = artikal.Cena;
                Kategorija k = prodavnicaEntities.Kategorija.SingleOrDefault(t => t.idKat == artikal.idKat);
                artikalBO.Kategorija = new KategorijaBO()
                {
                    idKat = k.idKat,
                    NazivKategorije = k.NazivKategorije
                };

                artikli.Add(artikalBO);
            }
            return artikli;
        }

        public ArtikalBO GetById(int ArtikalID)
        {
            Artikal artikal = prodavnicaEntities.Artikal.Single(t => t.ArtikalID == ArtikalID);
            Kategorija k = prodavnicaEntities.Kategorija.SingleOrDefault(t => t.idKat == artikal.idKat);
            ArtikalBO artikalBO = new ArtikalBO
            {
                ArtikalID = artikal.ArtikalID,
                NazivArtikla = artikal.NazivArtikla,
                Cena = artikal.Cena,
                Kategorija = new KategorijaBO
                {
                    idKat = k.idKat,
                    NazivKategorije = k.NazivKategorije
                }

            };
            return artikalBO;
        }

        public void IzmeniArtikal(ArtikalBO artikal)
        {
            Artikal artikalModel = prodavnicaEntities.Artikal.Single(t => t.ArtikalID == artikal.ArtikalID);

            try
            {
                artikalModel.ArtikalID = artikal.ArtikalID;
                artikalModel.NazivArtikla = artikal.NazivArtikla;
                artikalModel.Cena = artikal.Cena;
                artikalModel.idKat = artikal.Kategorija.idKat;

                prodavnicaEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Greška kod izmene artikla: " + ex);
                System.Diagnostics.Debug.WriteLine("Šifra artikla: " + artikal.ArtikalID + ", Naziv: " + artikal.NazivArtikla);

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

            public void ObrisiArtikal(int ArtikalID)
        {
            try
            {
                Artikal artikalModel = prodavnicaEntities.Artikal.Single(t => t.ArtikalID == ArtikalID);
                prodavnicaEntities.Artikal.Remove(artikalModel);
                prodavnicaEntities.SaveChanges();


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Greška kod brisanja Artikla sa šifrom: " + ArtikalID + "\n" + ex.ToString());

            }
        }

        public KorpaBO DodajKorpa(string kol, int id)
        {
            Artikal artikalModel = prodavnicaEntities.Artikal.Where(p => p.ArtikalID == id).SingleOrDefault();

            KorpaBO stavka = new KorpaBO();
            stavka.ArtikalID = artikalModel.ArtikalID;
            stavka.NazivArtikla = artikalModel.NazivArtikla;
            stavka.Cena = artikalModel.Cena;
            stavka.Kolicina = Convert.ToInt32(kol);
            stavka.UkupnaCena = stavka.Cena * stavka.Kolicina;

            return stavka; 

        }

        public bool postojiArtikal(int sifraArtikla)
        {
            Artikal artikal = prodavnicaEntities.Artikal.Find(sifraArtikla);
            if (artikal != null)
            {
                return true;
            }
            return false;
        }

        public void obrisiStavkeUPorudzbini(int idArt)
        {
            foreach (StavkaPorudzbine stv in prodavnicaEntities.StavkaPorudzbine.Where(t => t.ArtikalID == idArt))
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