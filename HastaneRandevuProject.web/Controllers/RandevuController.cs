using HastaneRandevuProject.web.Models;
using Microsoft.AspNetCore.Mvc;

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
            // Veritabanından doktorlar ve tarihleri çek
            var doktorlar = _context.Doktorlar.ToList();
            var tarihler = Enumerable.Range(0, 7).Select(i => DateTime.Today.AddDays(i)).ToList();

            var model = new RandevuAlModel
            {
                HastaID = 1, // Buraya gerçekten giriş yapmış hasta ID'si gelebilir
                Doktorlar = doktorlar,
                Tarihler = tarihler
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult RandevuAl(RandevuAlModel model)
        {
            // Randevu kaydetme işlemleri burada yapılacak
            // Seçilen doktor ve tarih bilgileri model.SecilenDoktorID ve model.SecilenTarih üzerinden alınabilir

            // Örnek olarak başarılı bir randevu aldığında başka bir sayfaya yönlendir
            return RedirectToAction("Randevularim", new { hastaID = model.HastaID });
        }
    }

}
