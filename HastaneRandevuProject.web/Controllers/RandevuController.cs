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
            // Veritabanından poliklinikleri çek
            var poliklinikler = _context.Poliklinikler.ToList();

            // İlk poliklinikteki doktorları çek
            var ilkPoliklinikID = poliklinikler.FirstOrDefault()?.PoliklinikID;
            var doktorlar = _context.Doktorlar
                .Where(d => d.PoliklinikID == ilkPoliklinikID)
                .ToList();

            var tarihler = Enumerable.Range(0, 7).Select(i => DateTime.Today.AddDays(i)).ToList();

            var model = new RandevuAlModel
            {
                HastaID = 1, // Buraya gerçekten giriş yapmış hasta ID'si gelebilir
                Poliklinikler = poliklinikler,
                Doktorlar = doktorlar,
                Tarihler = tarihler
            };

            return View(model);
        }

        public IActionResult GetDoktorlar(int poliklinikID)
        {
            // PoliklinikID'ye göre doktorları veritabanından çek
            var doktorlar = _context.Doktorlar
                .Where(d => d.PoliklinikID == poliklinikID)
                .Select(d => new { value = d.DoktorID, text = d.Adi })
                .ToList();

            return Json(doktorlar);
        }

        [HttpPost]
        public IActionResult RandevuAl(RandevuAlModel model)
        {
            if (ModelState.IsValid)
            {
                // Model doğrulaması geçtiğinde randevu kaydetme işlemleri burada yapılacak
                // Seçilen doktor ve tarih bilgileri model.SecilenDoktorID ve model.SecilenTarih üzerinden alınabilir

                // Örnek olarak başarılı bir randevu aldığında başka bir sayfaya yönlendir
                return RedirectToAction("Randevularim", new { hastaID = model.HastaID });
            }

            // Eğer model doğrulaması geçmezse, tekrar RandevuAl sayfasını göster
            // Hatalı alanlar ModelState.Errors içinde bulunabilir
            return View(model);
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
