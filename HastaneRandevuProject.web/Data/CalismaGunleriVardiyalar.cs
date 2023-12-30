// CalismaGunleriVardiyalar.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuProject.web.Models
{
    public class CalismaGunleriVardiyalar
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int DoktorID { get; set; }

        [Required]
        public DateTime CalismaGunu { get; set; }

        public string VardiyaSaati { get; set; } // Örneğin: "08:00", "16:00" vb.


        [Required]
        public int VardiyaTipi { get; set; } // Örneğin: 1 (08:00-16:00), 2 (16:00-24:00), 3 (24:00-08:00)
    }
}
