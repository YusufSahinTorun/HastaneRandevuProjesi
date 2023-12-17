using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Veritabanındaki AnaBilimDali tablosundaki verileri çek
        var anabilimDallari = _context.AnaBilimDali.ToList();

        // Bu verileri View'e geçir
        return View(anabilimDallari);
    }
}
