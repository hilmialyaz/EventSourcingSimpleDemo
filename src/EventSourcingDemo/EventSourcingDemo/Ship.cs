using EventSourcingDemo.Events;

namespace EventSourcingDemo
{
    public class Ship
    {
        private string v;

        public Ship(string v)
        {
            this.v = v;
        }

        public Port Port { get; set; }

        public void HandleDeparture(DepartureEvent departureEvent)
        {
            Port = Port.AT_SEA;
        }
    }
}