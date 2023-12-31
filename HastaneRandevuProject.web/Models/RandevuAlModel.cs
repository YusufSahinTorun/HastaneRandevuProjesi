using HastaneRandevuProject.web.Data;
using HastaneRandevuProject.web.Models;

public class RandevuAlModel
{
    public int HastaID { get; set; }
    public int SecilenPoliklinikID { get; set; }
    public int SecilenDoktorID { get; set; }
    public DateTime Tarih { get; set; }
    public string Saat { get; set; }



    public IEnumerable<Poliklinikler> Poliklinikler { get; set; } = Enumerable.Empty<Poliklinikler>();
    public IEnumerable<Doktorlar> Doktorlar { get; set; } = Enumerable.Empty<Doktorlar>();

}