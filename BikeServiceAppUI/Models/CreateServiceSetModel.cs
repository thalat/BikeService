using System.ComponentModel.DataAnnotations;

namespace BikeServiceAppUI.Models;

public class CreateServiceSetModel
{
   [Required]
   public ServiceSet ServiceSet { get; set; }
   public string Description { get; set; }
   [Required]
   public decimal Price { get; set; }
}
