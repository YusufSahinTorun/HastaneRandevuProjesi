using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuProject.web.Data
{
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }
        public int HastaID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        public Hasta Hasta { get; set; }
    }

}
