namespace HastaneRandevuProject.web.Data
{
    public class Randevu
    {
        public int RandevuID { get; set; }
        public int? DoktorID { get; set; }
        public int? HastaID { get; set; }
        public string Saat { get; set; }
        public DateTime Tarih { get; set; }

        public Doktorlar Doktor { get; set; }
        public Hasta Hasta { get; set; }
    }

}
