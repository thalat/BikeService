namespace BikeServiceAppLibrary.DataAccess;

public interface IClientData
{
   Task CreateClient(ClientModel user);
   Task<ClientModel> GetClient(string id);
   Task<ClientModel> GetClientByNumber(string phoneNumber);
   Task<ClientModel> GetClientFromAuthentication(string objectId);
   Task<List<ClientModel>> GetAllClients();
   Task UpdateClient(ClientModel client);
}
