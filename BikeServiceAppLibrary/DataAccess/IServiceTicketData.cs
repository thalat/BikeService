namespace BikeServiceAppLibrary.DataAccess;

public interface IServiceTicketData
{
   Task CreateServiceTicket(ServiceTicketModel serviceTicket, ClientModel owner);
   Task<List<ServiceTicketModel>> GetAllServiceTicketModels();
   Task<List<ServiceTicketModel>> GetAllServiceTicketModelsInService();
   Task<List<ServiceTicketModel>> GetAllServiceTicketOutsideTheService();
   Task<ServiceTicketModel> GetServiceTicket(string id);
   Task<ServiceTicketModel> GetServiceTicketFromAuthentication(string objectId);
   Task UpdateServiceTicket(ServiceTicketModel serviceTicketModel);
}