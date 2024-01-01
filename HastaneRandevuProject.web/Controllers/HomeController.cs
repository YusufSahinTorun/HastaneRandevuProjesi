using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string username, string password)

    {
        if (username == "b211210094@sakarya.edu.tr" && password == "sau")
        {
            return RedirectToAction("Admin");
        }
        ViewBag.PasswordError = null;
        ViewBag.GeneralError = null;

        var kullanici = _context.Kullanici.FirstOrDefault(x => x.KullaniciAdi == username && x.Sifre == password);
        if (username == "b211210094@sakarya.edu.tr" && password == "sau")
        {
            return RedirectToAction("Admin");
        }

        if (kullanici != null)
        {
            HttpContext.Session.SetInt32("HastaID", kullanici.HastaID);

            // Belirli bir kullanıcı adı ve şifre kontrolü
            if (username == "b211210094@sakarya.edu.tr" && password == "sau")
            {
                return RedirectToAction("Admin");
            }

            return RedirectToAction("Giris");
        }
        else
        {
            ViewBag.PasswordError = "Şifre hatalı.";
            ViewBag.GeneralError = "Kullanıcı adı veya şifre hatalı.";

            return View("Index");
        }
    }
    public IActionResult DoktorEkle()
    {
        var poliklinikler = _context.Poliklinikler.ToList();

        var model = new DoktorEkleModel
        {
            // Polikliniklerin listesini model içine ekleyin
            Poliklinikler = poliklinikler.Select(p => new SelectListItem { Value = p.PoliklinikID.ToString(), Text = p.Adi })
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult DoktorEkle(DoktorEkleModel model)
    {
        if (ModelState.IsValid)
        {
            // En yüksek DoktorID'yi bul
            int enYuksekDoktorID = _context.Doktorlar.Max(d => d.DoktorID);

            // Modelin Id'sini en yüksek DoktorID + 1 olarak ayarla
            model.Id = enYuksekDoktorID + 1;
            var yeniDoktor = new Doktorlar
            {
                DoktorID = enYuksekDoktorID+1,
                Adi = model.Adi,
                Soyadi = model.Soyadi,
                PoliklinikID = model.PoliklinikID
                // Diğer özellikleri de doldurun
            };


            _context.Doktorlar.Add(yeniDoktor);
            _context.SaveChanges();

            // Başarılı ekleme durumunda yönlendirme
            return RedirectToAction("AdminPanel");
        }

        // Eğer ModelState geçerli değilse, hata mesajlarıyla tekrar DoktorEkle sayfasını göster
        var poliklinikler = _context.Poliklinikler.ToList();

        model.Poliklinikler = poliklinikler.Select(p => new SelectListItem { Value = p.PoliklinikID.ToString(), Text = p.Adi });

        return Json(model);
    }


    public IActionResult Admin()
    {
        // Admin paneli için gerekli işlemleri yapabilirsiniz
        return View("Admin");
    }

    public IActionResult Giris()
    {
        var hastaID = HttpContext.Session.GetInt32("HastaID");
        return View();
    }

}
