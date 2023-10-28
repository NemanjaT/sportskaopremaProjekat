using SportskaOpremaNemanjaTutunovic.Models;
using SportskaOpremaNemanjaTutunovic.Models.EFRepository;
using SportskaOpremaNemanjaTutunovic.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportskaOpremaNemanjaTutunovic.Controllers
{
    public class ArtikalController : Controller
    {
        private IArtikalRepository _artikalRepository; 

        public ArtikalController()
        {
            _artikalRepository = new ArtikalRepository();
        }

// GET: Artikal
        [Authorize (Roles = "admin")]
        public ActionResult Index()
        {
            ViewBag.Artikli = _artikalRepository.GetAllArtikli();
            return View(_artikalRepository.GetAllArtikli());
        }

        public ActionResult IndexKorisnik()
        {
            if (TempData["korpa"] != null)
            {
                float racun = 0;
                List<KorpaBO> li2 = TempData["korpa"] as List<KorpaBO>;
                foreach (var item in li2)
                {
                    racun += item.UkupnaCena;

                }

                TempData["racun"] = racun;
            }
            TempData.Keep();
            ViewBag.Artikli = _artikalRepository.GetAllArtikli();
            return View(_artikalRepository.GetAllArtikli());
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.Kategorije = _artikalRepository.GetAllKategorije();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(ArtikalBO artikal)
        {
            ViewBag.Kategorije = _artikalRepository.GetAllKategorije();
            if (_artikalRepository.postojiArtikal(artikal.ArtikalID) == true)
            {
                ModelState.AddModelError("ArtikalID", "Artikal sa šifrom " + artikal.ArtikalID + " već postoji");
                System.Diagnostics.Debug.WriteLine("Dodat modelErr, id=" + artikal.ArtikalID);
                return View();
            }
          
            
                _artikalRepository.DodajArtikal(artikal);
                return RedirectToAction("Index");
            
           
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            
            
                ArtikalBO artikal = _artikalRepository.GetById(id);
                return View(artikal);
            
          
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(ArtikalBO artikal)
        {
            _artikalRepository.obrisiStavkeUPorudzbini(artikal.ArtikalID);
            _artikalRepository.ObrisiArtikal(artikal.ArtikalID);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            ViewBag.Kategorije = _artikalRepository.GetAllKategorije();
            if (id != null && id > 0)
            {
                int iid = id.Value;
                ArtikalBO artikal = _artikalRepository.GetById(iid);
                return View("Edit", artikal);
            }
            return View("Greska");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(ArtikalBO artikal)
        {
            if (_artikalRepository.postojiArtikal(artikal.ArtikalID) == false)
            {
                ModelState.AddModelError("SifraArtikla", "Artikal sa šifrom " + artikal.ArtikalID + "ne postoji u bazi");
                System.Diagnostics.Debug.WriteLine("Dodat modelErr, id=" + artikal.ArtikalID);
            }
                if (ModelState.IsValid)
            {
                _artikalRepository.IzmeniArtikal(artikal);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Korpa(int id)
        {
          ArtikalBO artikal =  _artikalRepository.GetById(id);
            return View(artikal);
        }

        List<KorpaBO> li = new List<KorpaBO>();
        [HttpPost]
        public ActionResult Korpa(int id, string kol)
        {
            KorpaBO korpa = _artikalRepository.DodajKorpa(kol, id);

            if(TempData["korpa"] == null)
            {
                li.Add(korpa);
                TempData["korpa"] = li;
            }
            else
            {
                List<KorpaBO> li2 = TempData["korpa"] as List<KorpaBO>;
                int pom = 0; 
                foreach(var item in li2)
                {
                    if(item.ArtikalID == korpa.ArtikalID)
                    {
                        item.Kolicina += korpa.Kolicina;
                        item.UkupnaCena += korpa.UkupnaCena;
                        pom = 1; 
                    }

                }

                if(pom == 0)
                {
                    li2.Add(korpa);
                }


               
                TempData["korpa"] = li2;
            }

            TempData.Keep();

            return RedirectToAction("IndexKorisnik");




        }

        public ActionResult PregledKorpe()
        {
            TempData.Keep();
            return View();
        }




     


    }
}