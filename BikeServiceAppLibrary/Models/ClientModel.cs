
namespace BikeServiceAppLibrary.Models;
public class ClientModel
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; }
   public string ObjectIdentifier { get; set; }
   public string Name { get; set; }
   public string LastName { get; set; }
   public string PhoneNumber { get; set; }
   public string Email { get; set; }
   public List<string> ServiceTicketIds { get; set; } = new();

}

