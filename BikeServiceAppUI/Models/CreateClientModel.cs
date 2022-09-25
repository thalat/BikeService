using System.ComponentModel.DataAnnotations;

namespace BikeServiceAppUI.Models;

public class CreateClientModel
{
   [Required]
   [MaxLength(75)]
   public string Name { get; set; }

   [Required]
   [MaxLength(75)]
   public string LastName { get; set; }

   [Required]
   [MaxLength(20)]
   public string PhoneNumber { get; set; }
}
