using HastaneRandevuProject.web.Data;

public class RandevuAlModel
{
    public int HastaID { get; set; }
    public int SecilenPoliklinikID { get; set; } // Değişen özellik (int olarak değiştirildi)
    public int SecilenDoktorID { get; set; }
    public DateTime SecilenTarih { get; set; }

    public IEnumerable<Poliklinikler> Poliklinikler { get; set; }
    public IEnumerable<Doktorlar> Doktorlar { get; set; }
    public IEnumerable<DateTime> Tarihler { get; set; }
}
