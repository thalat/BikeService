using Microsoft.Extensions.Caching.Memory;

namespace BikeServiceAppLibrary.DataAccess;
public class MongoServiceSetData : IServiceSetData
{
   private readonly IMongoCollection<ServiceSetModel> _serviceSets;
   private readonly IMemoryCache _cache;
   private const string CacheName = "ServiceSetData";

   public MongoServiceSetData(IDbConnection db, IMemoryCache cache)
   {
      _serviceSets = db.ServiceSetCollection;
      _cache = cache;
   }

   public async Task<List<ServiceSetModel>> GetAllServiceSets()
   {
      var output = _cache.Get<List<ServiceSetModel>>(CacheName);
      if (output is null)
      {
         var results = await _serviceSets.FindAsync(x => true);
         output = results.ToList();

         _cache.Set(CacheName, output, TimeSpan.FromDays(1));
      }
      return output;
   }

   public Task CreateServiceSet(ServiceSetModel serviceSet)
   {
      return _serviceSets.InsertOneAsync(serviceSet);
   }

   public Task DeleteServiceSet(ServiceSetModel serviceSet)
   {
      var filter = Builders<ServiceSetModel>.Filter.Eq("Id", serviceSet.Id);
      return _serviceSets.DeleteOneAsync(filter);
   }
}
