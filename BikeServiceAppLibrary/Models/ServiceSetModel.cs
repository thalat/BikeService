
namespace BikeServiceAppLibrary.Models;
public class ServiceSetModel
{

   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; }
   public ServiceSet ServiceSet { get; set; }
   public string Description { get; set; }
   public decimal Price { get; set; }

   //public ServiceSetModel(ServiceSetModel model)
   //{
   //   ServiceSet = model.ServiceSet;
   //   Description = model.Description;
   //   Price = model.Price;
   //}

   public ServiceSetModel(ServiceSet serviceSet)
   {
      ServiceSet = serviceSet;

      switch (ServiceSet)
      {
         case ServiceSet.Zerowy:
            Price = 75;
            break;
         case ServiceSet.ZerowyElektryczny:
            Price = 120;
            break;
         case ServiceSet.Roczny:
            Price = 120;
            break;
         case ServiceSet.UslugaSerwisowa:
            Price = 10;
            break;
      }
   }

}
