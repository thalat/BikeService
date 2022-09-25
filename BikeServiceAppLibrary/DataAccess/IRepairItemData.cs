namespace BikeServiceAppLibrary.DataAccess;

public interface IRepairItemData
{
   Task CreateRepairItem(RepairItemModel repairItem);
   Task<List<RepairItemModel>> GetLastRepairedItems(ClientModel client);
}