using HastaneRandevuProject.web.Models;
using HastaneRandevuProject.web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HastaneRandevuProject.web.Controllers
{
    public class RandevuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandevuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult RandevuAl()
        {
            var hastaID = HttpContext.Session.GetInt32("HastaID");

            var doktorlar = _context.Doktorlar.ToList();
            var poliklinikler = _context.Poliklinikler.ToList();

            var model = new RandevuAlModel
            {
                HastaID = hastaID ?? 0,
                Doktorlar = doktorlar,
                Poliklinikler = poliklinikler
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult RandevuAl(RandevuAlModel model)
        {
            var hastaID = HttpContext.Session.GetInt32("HastaID");

            if (ModelState.IsValid)
            {
                var randevu = new Randevu
                {
                    HastaID = hastaID,
                    DoktorID = model.SecilenDoktorID,
                    PoliklinikID = model.SecilenPoliklinikID, // Eklendi
                    Tarih = model.Tarih,
                    Saat = model.Saat
                };

                _context.Randevular.Add(randevu);
                _context.SaveChanges();

                return RedirectToAction("Randevularim", new { hastaID = model.HastaID });
            }
            else
            {
                // Model valid değilse, hataları göster
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"{key}: {error.ErrorMessage}");
                    }
                }
                return Json(model);

            }
        }


        public IActionResult GetDoktorlar(int poliklinikID)
        {
            // PoliklinikID'ye göre doktorları veritabanından çek
            var doktorlar = _context.Doktorlar
                .Where(d => d.PoliklinikID == poliklinikID)
                .Select(d => new { value = d.DoktorID, text = $"{d.Adi} {d.Soyadi}" })
                .ToList();

            return Json(doktorlar);
        }

        public IActionResult GetCalismaGunleri(int doktorID)
        {
            var calismaGunleri = _context.CalismaGunleriVardiyalar
                .Where(c => c.DoktorID == doktorID)
                .Select(c => new { value = c.ID, text = c.CalismaGunu, typeofv = c.VardiyaTipi })
                .ToList();

            return Json(calismaGunleri);

        }
        public IActionResult GetSaatler(int id)
        {
            var Saatler = _context.CalismaGunleriVardiyalar
                .Where(d => d.ID == id)
                .Select(d => new { value = d.ID, typeofvar = d.VardiyaTipi })
                .ToList();

            return Json(Saatler);
        }

        public IActionResult Randevularim(int hastaID)
        {
            // HastaID'ye göre randevuları çek
            var randevular = _context.Randevular
                .Include(r => r.Doktor)
                .Include(r => r.Poliklinik)
                .Where(r => r.HastaID == hastaID)
                .ToList();

            return View(randevular);
        }
    }
}