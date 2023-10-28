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
    public class PorudzbinaController : Controller
    {
        private IPorudzbinaRepository _porudzbinaRepository;
        private IAuthRepository authRepository = new AuthRepository();

        public PorudzbinaController()
        {

            _porudzbinaRepository = new PorudzbineRepository();
        }

        // GET: Porudzbina
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            
            return View(_porudzbinaRepository.GetAllPorudzbine());
        }

        public ActionResult IndexKorisnik(string korisnik)
        {

            int id = authRepository.GetUserId(korisnik);
            return View(_porudzbinaRepository.GetByUserId(id));
        }

        public ActionResult Poruci()
        {
            
            TempData.Keep();
            return View();
        }



        [HttpPost]
        public ActionResult Poruci(string korisnik)
        {
            List<KorpaBO> li = TempData["korpa"] as List<KorpaBO>;
            int racun = Convert.ToInt32(TempData["racun"]);
            int id = authRepository.GetUserId(korisnik);
            _porudzbinaRepository.DodajPorudzbinu(id, racun, li);

            TempData.Remove("racun");
            TempData.Remove("korpa");

            TempData["msg"] = "Uspesno porucivanje!!!";
            TempData.Keep();
            return RedirectToAction("IndexKorisnik", new { korisnik = korisnik });
        }

        public ActionResult Delete(int id)
        {
            PorudzbinaBO porudzbina = _porudzbinaRepository.GetById(id);
            return View(porudzbina);
        }

        [HttpPost]
        public ActionResult Delete(PorudzbinaBO porudzbina)
        {
            _porudzbinaRepository.obrisiStavkeUPorudzbini(porudzbina.PorudzbinaID);
            _porudzbinaRepository.StornirajPorudzbinu(porudzbina.PorudzbinaID);
            return RedirectToAction("Index");
        }

        public ActionResult Deletek(int id)
        {
            PorudzbinaBO porudzbina = _porudzbinaRepository.GetById(id);
            return View(porudzbina);
        }

        [HttpPost]
        public ActionResult Deletek(PorudzbinaBO porudzbina)
        {
            _porudzbinaRepository.obrisiStavkeUPorudzbini(porudzbina.PorudzbinaID);
            _porudzbinaRepository.StornirajPorudzbinu(porudzbina.PorudzbinaID);
            return RedirectToAction("IndexKorisnik");
        }
    }
}