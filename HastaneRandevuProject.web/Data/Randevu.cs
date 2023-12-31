namespace HastaneRandevuProject.web.Data
{
    public class Randevu
    {
        public int RandevuID { get; set; }
        public int? DoktorID { get; set; }
        public int? HastaID { get; set; }
        public int? PoliklinikID { get; set; } // Eklenen özellik
        public string Saat { get; set; }
        public DateTime Tarih { get; set; }


        public Doktorlar Doktor { get; set; }
        public Hasta Hasta { get; set; }
        public Poliklinikler Poliklinik { get; set; } // Eklenen özellik
    }
}
