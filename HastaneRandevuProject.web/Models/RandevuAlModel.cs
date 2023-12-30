using HastaneRandevuProject.web.Data;
using HastaneRandevuProject.web.Models;

public class RandevuAlModel
{
    public int HastaID { get; set; }
    public int SecilenPoliklinikID { get; set; }
    public int SecilenDoktorID { get; set; }

    // Yeni özellikler
    public DateTime SecilenTarih { get; set; }
    public int SecilenVardiyaTipi { get; set; }  // Vardiya tipi özelliği eklendi
    public String SecilenSaat { get; set; }  // Saat, TimeSpan türünde tutulacak


    public ICollection<CalismaGunleriVardiyalar> CalismaTarihi { get; set; }
    public IEnumerable<Poliklinikler> Poliklinikler { get; set; } = Enumerable.Empty<Poliklinikler>();
    public IEnumerable<Doktorlar> Doktorlar { get; set; } = Enumerable.Empty<Doktorlar>();
    public IEnumerable<DateTime> Tarihler { get; set; } = Enumerable.Empty<DateTime>();
}