namespace HastaneRandevuProject.web.Models
{
    public class RandevuAlModel
    {
        public int HastaID { get; set; }
        public int SecilenDoktorID { get; set; }
        public DateTime SecilenTarih { get; set; }

        public IEnumerable<Doktorlar> Doktorlar { get; set; }
        public IEnumerable<DateTime> Tarihler { get; set; }
    }

}
