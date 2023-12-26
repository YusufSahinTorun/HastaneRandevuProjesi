using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    public ActionResult GirisKontrol(string username, string password)
    {
        // Veritabanında kullanıcıyı sorgula
        var kullanici = _context.Kullanici.FirstOrDefault(x => x.KullaniciAdi == username && x.Sifre == password);

        if (kullanici != null)
        {
            // Kullanıcı doğrulandı, oturumu başlat veya kimlik doğrulama işlemlerini gerçekleştir
            // Örneğin: FormsAuthentication.SetAuthCookie(username, false);
            // veya: HttpContext.Current.Session["KullaniciAdi"] = username;

            return RedirectToAction("Privacy"); // Başarılı giriş durumunda yönlendirilecek sayfa
        }
        else
        {
            // Kullanıcı doğrulanamadı, hata mesajı göster
            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            return View("Index");
        }
    }

public IActionResult Index()
    {
        // Veritabanındaki AnaBilimDali tablosundaki verileri çek
        var anabilimDallari = _context.AnaBilimDali.ToList();

        // Bu verileri View'e geçir
        return View(anabilimDallari);
    }
}