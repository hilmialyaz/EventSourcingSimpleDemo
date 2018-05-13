using System;

namespace EventSourcingDemo.Events
{
    public class LoadEvent :DomainEvent
    {
        private int _shipCode;
        private string _cargoCode;
        public Port priorPort;
        private Port _port;
        private Ship _ship;

        public LoadEvent(DateTime dateTime, Cargo refact, Ship kr) : base(dateTime)
        {
           
        }

        internal LoadEvent(DateTime occurred, string cargo, int ship) : base(occurred)
        {
            _shipCode = ship;
            _cargoCode = cargo;
        }

        internal Ship Ship { get { return Ship.Find(_shipCode); } }
        internal Cargo Cargo { get { return Cargo.Find(_cargoCode); } }

        internal override void Process()
        {
            Cargo.HandleLoad(this);
        }

        internal override void Reverse()
        {
            Cargo.ReverseLoad(this);
        }

        internal void HandleLoad(LoadEvent ev)
        {
            ev.priorPort = _port;
            _port = null;
            _ship = ev.Ship;
            _ship.HandleLoad(ev);
        }
    }
}