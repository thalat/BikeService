
namespace BikeServiceAppLibrary.Models;
public class StatusModel
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; }
   public string StatusName { get; set; }
}
