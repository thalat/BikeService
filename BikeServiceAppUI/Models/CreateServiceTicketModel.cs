using System.ComponentModel.DataAnnotations;

namespace BikeServiceAppUI.Models;

public class CreateServiceTicketModel
{
   [Required]
   [MinLength(length: 1)]
   public string StatusId { get; set; }
   public List<RepairPartModel> RepairParts { get; set; } = new();
   [Required]
   public DateTime ExpectedEndDate { get; set; }
   [Required]
   public ServiceSetModel ServiceSet { get; set; }

   public bool Archived { get; set; } = false;
   public bool InService { get; set; } = true;
   [Required]
   public ClientModel Client { get; set; }
   [Required]
   public RepairItemModel RepairItem { get; set; }
   public string Description { get; set; }
}
