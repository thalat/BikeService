namespace BikeServiceAppLibrary.Models;
public class RepairItemModel
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; }
   public ProductType ProductType { get; set; }
   public string Brand { get; set; }
   public string Model { get; set; }

}
