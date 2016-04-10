﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muzak.Domain
{
    public class Shipment : AggregateRoot
    {
        private Guid _id;
        private decimal Weight;

        //private void Apply(ShipmentCreated e)
        //{
        //    _id = e.Id;
        //}

        public override Guid Id
        {
            get { return _id; }
        }

        public Shipment()
        {

        }
        public Shipment(Guid id, decimal weight, int quantity, decimal freightClass, string country)
        {
            if (weight > 5000) throw new InvalidOperationException("Weight cannot be greater than 5,000 lbs.");

            //ApplyChange(new ShipmentCreated(id, weight, quantity, freightClass, country, "test" ));

        }
    }

    public abstract class AggregateRoot
    {
        private readonly List<Event> _changes = new List<Event>();

        public abstract Guid Id { get; }
        public int Version { get; internal set; }

        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history) ApplyChange(e, false);
        }

        protected void ApplyChange(Event @event)
        {
            ApplyChange(@event, true);
        }

        // push atomic aggregate changes to local history for further processing (EventStore.SaveEvents)
        private void ApplyChange(Event e, bool isNew)
        {
            RedirectToWhen.InvokeEventOptional(this, e);
            //this.AsDynamic().Apply(@event);
            if (isNew) _changes.Add(e);
        }
    }

    public interface IRepository<T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid id);
    }

    public class Repository<T> : IRepository<T> where T : AggregateRoot, new() //shortcut you can do as you see fit with new()
    {
        private readonly IEventStore _storage;

        public Repository(IEventStore storage)
        {
            _storage = storage;
        }

        public void Save(AggregateRoot aggregate, int expectedVersion)
        {
            _storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
        }

        public T GetById(Guid id)
        {
            var obj = new T();//lots of ways to do this
            var e = _storage.GetEventsForAggregate(id);
            obj.LoadsFromHistory(e);
            return obj;
        }
    }
}
