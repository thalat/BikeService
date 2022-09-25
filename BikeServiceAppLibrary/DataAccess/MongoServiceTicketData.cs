using Microsoft.Extensions.Caching.Memory;

namespace BikeServiceAppLibrary.DataAccess;
public class MongoServiceTicketData : IServiceTicketData
{
   private readonly IDbConnection _db;
   private readonly IMongoCollection<ServiceTicketModel> _serviceTickets;
   private readonly IMemoryCache _cache;
   private readonly IClientData _clientData;
   private const string CacheName = "ServiceTicketData";

   public MongoServiceTicketData(IDbConnection db, IMemoryCache cache, IClientData clientData)
   {
      _db = db;
      _serviceTickets = db.ServiceTicketCollection;
      _cache = cache;
      _clientData = clientData;
   }

   public async Task<List<ServiceTicketModel>> GetAllServiceTicketModels()
   {
      var output = _cache.Get<List<ServiceTicketModel>>(CacheName);
      if (output is null)
      {
         var results = await _serviceTickets.FindAsync(x => x.Archived == false);
         output = results.ToList();

         _cache.Set(CacheName, output, TimeSpan.FromMinutes(1));
      }
      return output;
   }

   public async Task<List<ServiceTicketModel>> GetAllServiceTicketModelsInService()
   {
      var output = await GetAllServiceTicketModels();
      return output.Where(x => x.InService).ToList();
   }

   public async Task<ServiceTicketModel> GetServiceTicket(string id)
   {
      var results = await _serviceTickets.FindAsync(x => x.Id == id);
      return results.FirstOrDefault();
   }

   public async Task<List<ServiceTicketModel>> GetAllServiceTicketOutsideTheService()
   {
      var output = await GetAllServiceTicketModels();
      return output.Where(x => x.InService == false).ToList();
   }

   public async Task<ServiceTicketModel> GetServiceTicketFromAuthentication(string objectId)
   {
      var results = await _serviceTickets.FindAsync(u => u.ObjectIdentifier == objectId);
      return results.FirstOrDefault();
   }

   public async Task CreateServiceTicket(ServiceTicketModel serviceTicket, ClientModel owner)
   {
      var client = _db.Client;

      using var session = await client.StartSessionAsync();

      session.StartTransaction();

      try
      {
         var db = client.GetDatabase(_db.DbName);

         var serviceTicketsInTransaction = db.GetCollection<ServiceTicketModel>(_db.ServiceTicketCollectionName);
         await serviceTicketsInTransaction.InsertOneAsync(serviceTicket);

         // todo handle scenario when client exists
         var clientsInTransaction = db.GetCollection<ClientModel>(_db.ClientCollectionName);
         await clientsInTransaction.InsertOneAsync(owner);

         await session.CommitTransactionAsync();

      }
      catch (Exception ex)
      {
         await session.AbortTransactionAsync();
         throw;
      }
   }

   public async Task UpdateServiceTicket(ServiceTicketModel serviceTicketModel)
   {
      await _serviceTickets.ReplaceOneAsync(x => x.Id == serviceTicketModel.Id, serviceTicketModel);
      _cache.Remove(CacheName);
   }



}
