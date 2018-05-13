using System;

namespace EventSourcingDemo.Events
{
    public class DepartureEvent : DomainEvent
    {
        private Port _port;
        private Ship _ship;
        internal Port Port { get { return _port; } }
        internal Ship Ship { get { return _ship; } }

        public DepartureEvent(DateTime time, Port port, Ship ship) : base(time)
        {
            _port = port;
            _ship = ship;
        }

        internal override void Process()
        {
            Ship.HandleDeparture(this);
        }

        internal override void Reverse()
        {
            
        }
    }
}