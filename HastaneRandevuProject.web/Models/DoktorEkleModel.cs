using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class DoktorEkleModel
{
    [Required(ErrorMessage = "Adı zorunlu bir alan.")]

    public int Id { get; set; }
    public string Adi { get; set; }

    [Required(ErrorMessage = "Soyadı zorunlu bir alan.")]
    public string Soyadi { get; set; }

    [Required(ErrorMessage = "Poliklinik seçimi zorunlu bir alan.")]
    public int PoliklinikID { get; set; }

    // Diğer gerekli özellikleri de ekleyebilirsiniz

    // Bu özelliği ekleyin
    public IEnumerable<SelectListItem> Poliklinikler { get; set; }
}
