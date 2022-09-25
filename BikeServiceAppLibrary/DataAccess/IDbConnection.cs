namespace BikeServiceAppLibrary.DataAccess;
public interface IDbConnection
{
   MongoClient Client { get; }
   IMongoCollection<ClientModel> ClientCollection { get; }
   string ClientCollectionName { get; }
   string DbName { get; }
   IMongoCollection<RepairItemModel> RepairItemCollection { get; }
   string RepairItemCollectionName { get; }
   IMongoCollection<RepairPartModel> RepairPartCollection { get; }
   string RepairPartCollectionName { get; }
   IMongoCollection<ServiceSetModel> ServiceSetCollection { get; }
   string ServiceSetCollectionName { get; }
   IMongoCollection<ServiceTicketModel> ServiceTicketCollection { get; }
   string ServiceTicketCollectionName { get; }
   IMongoCollection<StatusModel> StatusCollection { get; }
   string StatusCollectionName { get; }
}
