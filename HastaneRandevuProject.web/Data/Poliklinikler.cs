namespace HastaneRandevuProject.web.Data
{
    public class Poliklinikler
    {
        public int PoliklinikID { get; set; }
        public string Adi { get; set; }
        public int? AnaBilimDaliID { get; set; }

        public AnaBilimDali AnaBilimDali { get; set; }
    }

}
