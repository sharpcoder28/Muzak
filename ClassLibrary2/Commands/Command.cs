using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muzak.Domain
{
    public class Command : Message
    {
    }

    public class CreateShipment : Command
    {
        public readonly Guid ShipmentID;
        public readonly decimal Weight;
        public readonly int Quantity;
        public readonly decimal FreightClass;
        public readonly string Country;

        public CreateShipment(Guid shipmentID, decimal weight, int quantity, decimal freightClass, 
            string country)
        {
            ShipmentID = shipmentID;
            Weight = weight;
            Quantity = quantity;
            FreightClass = freightClass;
            Country = country;
        }
    }
}
