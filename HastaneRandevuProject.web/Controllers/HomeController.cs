using Microsoft.AspNetCore.Mvc;
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
        // Veritabanında kullanıcıyı sorgula
        ViewBag.PasswordError = null;
        ViewBag.GeneralError = null;
        var kullanici = _context.Kullanici.FirstOrDefault(x => x.KullaniciAdi == username && x.Sifre == password);

        if (kullanici != null)
        {
            // Kullanıcı doğrulandı, oturumu başlat veya kimlik doğrulama işlemlerini gerçekleştir
            // Örneğin: FormsAuthentication.SetAuthCookie(username, false);
            // veya: HttpContext.Current.Session["KullaniciAdi"] = username;

            return RedirectToAction("Giris"); // Başarılı giriş durumunda yönlendirilecek sayfa
        }
        else
        {
            // Şifre yanlış ise sadece şifre hatası eklenir
            ViewBag.PasswordError = "Şifre hatalı.";

            // Kullanıcı doğrulanamadı, hata mesajı göster
            ViewBag.GeneralError = "Kullanıcı adı veya şifre hatalı.";

            // Hata durumunda tekrar Index sayfasını göster
            return View("Index");
        }
    }

    public IActionResult Giris()
    {
        return View();
    }

}
