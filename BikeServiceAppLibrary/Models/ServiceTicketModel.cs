namespace BikeServiceAppLibrary.Models;
public class ServiceTicketModel
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; }
   public string ObjectIdentifier { get; set; }
   public List<RepairPartModel> RepairParts { get; set; } = new();
   public DateTime ExpectedEndDate { get; set; }
   public ServiceSetModel ServiceSet { get; set; }
   public StatusModel ServiceTicketStatus { get; set; }
   public bool Archived { get; set; } = false;
   public bool InService { get; set; } = true;

   public ClientModel Client { get; set; }
   public RepairItemModel RepairItem { get; set; }
   public string Description { get; set; }

}
