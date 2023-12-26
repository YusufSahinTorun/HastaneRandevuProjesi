namespace HastaneRandevuProject.web.Data
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public int HastaID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        public Hasta Hasta { get; set; }
    }

}
