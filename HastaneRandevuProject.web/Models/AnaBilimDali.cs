using System.ComponentModel.DataAnnotations;

public class AnaBilimDali
{
    [Key]
    public int AnaBilimDaliID { get; set; }

    [Required]
    [StringLength(255)]
    public string Adi { get; set; }
}
