using System;

namespace EventSourcingDemo.Events
{
    public class ArrivalEvent : DomainEvent
    {
        public ArrivalEvent(DateTime occurred, Port port, Ship ship):base(occurred)
        {
            this.Port = port;
            this.Ship = ship;
        }

        internal Port Port { get; }

        internal Ship Ship { get; }

        internal override void Process()
        {
            Ship.HandleArrival(this);
        }
    }
}