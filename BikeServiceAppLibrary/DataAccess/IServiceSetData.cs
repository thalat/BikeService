namespace BikeServiceAppLibrary.DataAccess;

public interface IServiceSetData
{
   Task CreateServiceSet(ServiceSetModel serviceSet);
   Task<List<ServiceSetModel>> GetAllServiceSets();
   Task DeleteServiceSet(ServiceSetModel serviceSet);
}
