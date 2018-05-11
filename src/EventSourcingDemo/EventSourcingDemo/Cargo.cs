using EventSourcingDemo.Enums;
using EventSourcingDemo.Events;

namespace EventSourcingDemo
{
    public class Cargo
    {
        public Cargo(string refactoring)
        {
            
        }

        public bool HasBeenInCanda { get; set; }

        public void HandleArrival(ArrivalEvent ev)
        {
            if (Country.CANADA == ev.Port.Country)
                HasBeenInCanda = true;
        }
    }
}