
namespace BikeServiceAppLibrary.DataAccess;
public class MongoClientData : IClientData
{
   private readonly IMongoCollection<ClientModel> _clients;
   public MongoClientData(IDbConnection db)
   {
      _clients = db.ClientCollection;
   }

   public async Task<List<ClientModel>> GetAllClients()
   {
      var results = await _clients.FindAsync(x => true);
      return results.ToList();
   }

   public async Task<ClientModel> GetClient(string id)
   {
      var results = await _clients.FindAsync(u => u.Id == id);
      return results.FirstOrDefault();
   }

   public async Task<ClientModel> GetClientByNumber(string phoneNumber)
   {
      var results = await _clients.FindAsync(u => u.PhoneNumber == phoneNumber);
      return results.FirstOrDefault();
   }

   public async Task<ClientModel> GetClientFromAuthentication(string objectId)
   {
      var results = await _clients.FindAsync(u => u.ObjectIdentifier == objectId);
      return results.FirstOrDefault();
   }

   public Task CreateClient(ClientModel user)
   {
      return _clients.InsertOneAsync(user);
   }

   public Task UpdateClient(ClientModel client)
   {
      var filter = Builders<ClientModel>.Filter.Eq("Id", client.Id);
      return _clients.ReplaceOneAsync(filter, client, new ReplaceOptions { IsUpsert = true });
   }

}
