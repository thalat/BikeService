
namespace BikeServiceAppLibrary.DataAccess;
public class MongoRepairItemData : IRepairItemData
{
   private readonly IMongoCollection<RepairItemModel> _repairItems;

   public MongoRepairItemData(IDbConnection db)
   {
      _repairItems = db.RepairItemCollection;
   }

   public async Task<List<RepairItemModel>> GetLastRepairedItems(ClientModel client)
   {
      var filter = Builders<RepairItemModel>.Filter.Eq("Id", client.Id);
      var results = await _repairItems.FindAsync(filter);
      return results.ToList();

   }

   public Task CreateRepairItem(RepairItemModel repairItem)
   {
      return _repairItems.InsertOneAsync(repairItem);
   }
}
