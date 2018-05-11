using EventSourcingDemo.Enums;
using EventSourcingDemo.Events;
using EventSourcingDemo.Gateway;

namespace EventSourcingDemo
{
    public class Port
    {
        private string v;
        private Country uS;
        public static Port AT_SEA;

        public Port(string v, Country uS)
        {
            this.v = v;
            this.uS = uS;
        }

        public string Country{ get; set; }

        public void HandleArrival(ArrivalEvent ev)
        {
            ev.Ship.Port = this;
            Registry.CustomsNotificationGateway.Notify(ev.Occurred, ev.Ship, ev.Port);
        }
    }

    public class Registry
    {
        public static CustomsNotificationGateway CustomsNotificationGateway { get; set; }
    }
}