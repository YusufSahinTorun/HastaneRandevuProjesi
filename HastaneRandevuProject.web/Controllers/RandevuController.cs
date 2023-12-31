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
            if (ModelState.IsValid)
            {
                var randevu = new Randevu
                {
                    HastaID = model.HastaID,
                    DoktorID = model.SecilenDoktorID,
                    Tarih = model.Tarih, // Buradaki Tarih özelliğini uygun bir şekilde güncellemeniz gerekiyor
                    Saat = model.Saat // Saat özelliğini uygun bir şekilde güncellemeniz gerekiyor
                };

                _context.Randevular.Add(randevu);
                _context.SaveChanges();

                return RedirectToAction("Randevularim", new { hastaID = model.HastaID });
            }

            // Eğer model geçerli değilse, tekrar RandevuAl view'ına dön
            // Modeldeki validasyon hataları kullanıcılara gösterilecek
            return View(model);
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
                .Select(c => new { value = c.ID, text = $"{c.CalismaGunu}", VardiyaTipi = $"{c.VardiyaTipi}" })
                .ToList();

            return Json(calismaGunleri);

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
