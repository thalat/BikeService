using System.ComponentModel.DataAnnotations;

namespace BikeServiceAppUI.Models;

public class CreateRepairItemModel
{
   [Required]
   public ProductType ProductType { get; set; }
   [Required]
   public string Brand { get; set; }
   [Required]
   public string Model { get; set; }
}
