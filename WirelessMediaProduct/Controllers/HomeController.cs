using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WirelessMediaProduct.Models;
using DataLibrary;
using static DataLibrary.Logika.ProcesPodaci;

namespace WirelessMediaProduct.Controllers
{
    public class HomeController : Controller
    {
        List<ProductData> podaci = new List<ProductData>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(podaci.OrderBy(s => s.id).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult ViewProizvode()
        {
            ViewBag.Message = "Lista proizvoda";
            var data = UcitajPodatke();
           

            foreach(var row in data)
            {
                podaci.Add(new ProductData
                {
                    id = row.Id,
                    naziv = row.Naziv,
                    opis = row.Opis,
                    kategorija = row.Kategorija,
                    proizvodjac = row.Proizvodjac,
                    dobavljac = row.Dobavljac,
                    cena = row.Cena
                });
            }
            return View(podaci);
        }
        public IActionResult Prijava()
        {
            ViewBag.Message = "Novi proizvod";
            return View();
        }
        [HttpPost]
        public ActionResult Prijava(ProductData model)
        {
            if (ModelState.IsValid)
            {
                int proizvodKreiran=NoviProizvod(model.id, model.naziv, model.opis,
                    model.kategorija, model.proizvodjac, model.dobavljac, model.cena);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var pro = podaci.Where(p => p.id == id).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(ProductData pro)
        {
            var proi = podaci.Where(s => s.id == pro.id).FirstOrDefault();
            podaci.Remove(proi);
            podaci.Add(pro);

            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
