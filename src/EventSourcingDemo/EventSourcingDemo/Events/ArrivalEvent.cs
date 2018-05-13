using System;
using System.Collections;

namespace EventSourcingDemo.Events
{
    public class ArrivalEvent : DomainEvent
    {
        internal Port priorPort;
        internal IDictionary priorCargoInCanada = new Hashtable();

        public ArrivalEvent(DateTime occurred, Port port, Ship ship):base(occurred)
        {
            this.Port = port;
            this.Ship = ship;
            Occurred = occurred;
        }

        internal Port Port { get; }

        internal Ship Ship { get; }
        public DateTime Occurred { get; set; }

        internal override void Process()
        {
            Ship.HandleArrival(this);
        }

        internal override void Reverse()
        {
            
        }
    }
}