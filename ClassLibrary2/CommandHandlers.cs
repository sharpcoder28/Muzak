using Muzak.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muzak.Domain
{
    public class ArtistCommandHandlers
    {
        private readonly IRepository<Shipment> _repository;

        public ArtistCommandHandlers(IRepository<Shipment> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateArtist artist)
        {
            var artist = new Artist(artist.Id, artist.Name);

            //var shipment = new Shipment(message.ShipmentID, message.Weight,
            //    message.Quantity, message.FreightClass, message.Country);

            //_repository.Save(shipment, -1);
        }
    }
}
