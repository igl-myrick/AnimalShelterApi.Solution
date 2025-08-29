using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    [Required]
    [StringLength(20)]
    public string Species { get; set; }
    [Required]
    [StringLength(40)]
    public string Breed { get; set; }
    [Required]
    [Range(0, 50, ErrorMessage = "Age must be between 0 and 50.")]
    public int Age { get; set; }
  }
}