//using Newtonsoft.Json;
//using StackExchange.Redis;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Muzak.Domain
//{
//    public class ReadModel : IReadModelFacade
//    {
//        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
//        {
//            return ConnectionMultiplexer.Connect("devblueship.redis.cache.windows.net,abortConnect=false,ssl=true,password=/FRHsAU2JB8nqQqtRibKdoStjJ7Wj0Y/79eCfWcDOx4=");
//        });

//        public static ConnectionMultiplexer Connection
//        {
//            get
//            {
//                return lazyConnection.Value;
//            }
//        }

//        public IEnumerable<ShipmentListDto> GetShipments()
//        {
//            IDatabase cache = Connection.GetDatabase();

//            var cList = cache.ListRange("ShipmentListView", 0, -1);

//            var shipments = cList.Select(x => JsonConvert.DeserializeObject<ShipmentListDto>(x))
//                .ToList();

//            return shipments;
//        }

//        public ShipmentDetailsDto GetShipmentDetails(Guid id)
//        {
//            IDatabase cache = Connection.GetDatabase();

//            var detailsJson = cache.StringGet("ShipmentDetails:" + id.ToString());

//            var details = JsonConvert.DeserializeObject<ShipmentDetailsDto>(detailsJson);

//            return details;
//        }
//    }

//    public interface IReadModelFacade
//    {
//        IEnumerable<ShipmentListDto> GetShipments();
//        ShipmentDetailsDto GetShipmentDetails(Guid id);
//    }

//    public class ShipmentDetailsDto
//    {
//        public Guid Id;
//        public string Description;
//        public decimal FreightClass;
//        public int Version;

//        public ShipmentDetailsDto(Guid id, string description, decimal freightClass, int version)
//        {
//            Id = id;
//            Description = description;
//            FreightClass = freightClass;
//            Version = version;
//        }
//    }

//    public class ShipmentListDto
//    {
//        public Guid Id;
//        public string Description;
//        public string Country;
//        public int Quantity;

//        public ShipmentListDto(Guid id, int quantity, string description, string country)
//        {
//            Id = id;
//            Quantity = quantity;
//            Description = description;
//            Country = country;
//        }
//    }



//    public class ShipmentDetailsView : Handles<ShipmentCreated>
//    {
//        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
//        {
//            return ConnectionMultiplexer.Connect("devblueship.redis.cache.windows.net,abortConnect=false,ssl=true,password=/FRHsAU2JB8nqQqtRibKdoStjJ7Wj0Y/79eCfWcDOx4=");
//        });

//        public static ConnectionMultiplexer Connection
//        {
//            get
//            {
//                return lazyConnection.Value;
//            }
//        }

//        public void Handle(ShipmentCreated message)
//        {
//            var dto = new ShipmentDetailsDto(message.Id, message.Description, message.FreightClass,
//                message.Version);

//            IDatabase cache = Connection.GetDatabase();

//            cache.StringSet("ShipmentDetails" + message.Id.ToString(), JsonConvert.SerializeObject(dto));
//        }
//    }

//    public class ShipmentListView : Handles<ShipmentCreated>
//    {
//        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
//        {
//            return ConnectionMultiplexer.Connect("devblueship.redis.cache.windows.net,abortConnect=false,ssl=true,password=/FRHsAU2JB8nqQqtRibKdoStjJ7Wj0Y/79eCfWcDOx4=");
//        });

//        public static ConnectionMultiplexer Connection
//        {
//            get
//            {
//                return lazyConnection.Value;
//            }
//        }

//        public void Handle(ShipmentCreated message)
//        {
//            var dto = new ShipmentListDto(message.Id, message.Quantity, message.Description, 
//                message.Country);

//            IDatabase cache = Connection.GetDatabase();

//            cache.ListLeftPush("ShipmentListView", JsonConvert.SerializeObject(dto));

//            ///BullShitDatabase.list.Add(new InventoryItemListDto(message.Id, message.Name));
//        }

//        //public void Handle(InventoryItemRenamed message)
//        //{
//        //    var item = BullShitDatabase.list.Find(x => x.Id == message.Id);
//        //    item.Name = message.NewName;
//        //}

//        //public void Handle(InventoryItemDeactivated message)
//        //{
//        //    BullShitDatabase.list.RemoveAll(x => x.Id == message.Id);
//        //}
//    }
//}
