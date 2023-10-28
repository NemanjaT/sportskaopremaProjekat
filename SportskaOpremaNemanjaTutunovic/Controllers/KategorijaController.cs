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
    public class KategorijaController : Controller
    {
        private IKategorijaRepository _kategorijaRepository;

        public KategorijaController()
        {
            _kategorijaRepository = new KategorijaRepository();
        }
        // GET: Kategorija
        public ActionResult Index()
        {
            ViewBag.Kategorije = _kategorijaRepository.GetAllKategorije();
            return View(_kategorijaRepository.GetAllKategorije());
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(KategorijaBO kategorija)
        {
            if (_kategorijaRepository.postojiKategorija(kategorija.idKat) == true)
            {
                ModelState.AddModelError("idKat", "Kategorija sa šifrom " + kategorija.idKat + " već postoji");
                System.Diagnostics.Debug.WriteLine("Dodat modelErr, id=" + kategorija.idKat);
            }
            if (ModelState.IsValid)
            {
                _kategorijaRepository.DodajKategoriju(kategorija);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            KategorijaBO kategorija = _kategorijaRepository.GetById(id);
            return View(kategorija);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(KategorijaBO kategorija)
        {
            _kategorijaRepository.obrisiArtikleUKategoriji(kategorija.idKat);
            _kategorijaRepository.UkloniKategoriju(kategorija);
            return RedirectToAction("Index");
        }
    }
}