using System.Collections;
using EventSourcingDemo.Events;

namespace EventSourcingDemo
{
    public class Ship
    {
        private string v;
        private IList cargo;

        public Ship(string v)
        {
            this.v = v;
        }

        public Port Port { get; set; }

        public void HandleDeparture(DepartureEvent departureEvent)
        {
            Port = Port.AT_SEA;
        }

        public void HandleArrival(ArrivalEvent ev)
        {
            Port = ev.Port;
            foreach (Cargo c in cargo)
            {
                c.HandleArrival(ev);
            }
        }
    }
}