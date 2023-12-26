﻿using System.ComponentModel.DataAnnotations;

public class Doktorlar
{
    [Key]
    public int DoktorID { get; set; }

    [Required]
    public string Adi { get; set; }

    [Required]
    public int PoliklinikID { get; set; }

    [Required]
    public string Soyadi { get; set; }

    // Navigation property
    public AnaBilimDali AnaBilimDali { get; set; }
}