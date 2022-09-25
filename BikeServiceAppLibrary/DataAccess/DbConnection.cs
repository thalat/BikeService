using Microsoft.Extensions.Configuration;

namespace BikeServiceAppLibrary.DataAccess;
public class DbConnection : IDbConnection
{
   private readonly IConfiguration _config;
   private readonly IMongoDatabase _db;
   private string _connectionId = "MongoDB";

   public string DbName
   {

      get; private set;
   }

   public string ClientCollectionName { get; private set; } = "clients";
   public string RepairItemCollectionName { get; private set; } = "repairItems";
   public string RepairPartCollectionName { get; private set; } = "repairParts";
   public string ServiceSetCollectionName { get; private set; } = "serviceSets";
   public string ServiceTicketCollectionName { get; private set; } = "serviceTickets";
   public string StatusCollectionName { get; private set; } = "statuses";

   public MongoClient Client { get; private set; }

   public IMongoCollection<ClientModel> ClientCollection { get; private set; }
   public IMongoCollection<RepairItemModel> RepairItemCollection { get; private set; }
   public IMongoCollection<RepairPartModel> RepairPartCollection { get; private set; }
   public IMongoCollection<ServiceSetModel> ServiceSetCollection { get; private set; }
   public IMongoCollection<ServiceTicketModel> ServiceTicketCollection { get; private set; }
   public IMongoCollection<StatusModel> StatusCollection { get; private set; }

   public DbConnection(IConfiguration config)
   {
      _config = config;
      Client = new MongoClient(_config.GetConnectionString(_connectionId));
      DbName = _config["DatabaseName"];
      _db = Client.GetDatabase(DbName);

      ClientCollection = _db.GetCollection<ClientModel>(ClientCollectionName);
      RepairItemCollection = _db.GetCollection<RepairItemModel>(RepairItemCollectionName);
      RepairPartCollection = _db.GetCollection<RepairPartModel>(RepairPartCollectionName);
      ServiceSetCollection = _db.GetCollection<ServiceSetModel>(ServiceSetCollectionName);
      ServiceTicketCollection = _db.GetCollection<ServiceTicketModel>(ServiceTicketCollectionName);
      StatusCollection = _db.GetCollection<StatusModel>(StatusCollectionName);


   }
}
