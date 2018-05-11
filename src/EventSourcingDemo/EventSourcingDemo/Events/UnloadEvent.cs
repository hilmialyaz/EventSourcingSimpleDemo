using System;

namespace EventSourcingDemo.Events
{
    public class UnloadEvent:DomainEvent
    {
        public UnloadEvent(DateTime dateTime, Cargo refact, Ship kr):base(dateTime)
        {
            refact.HasBeenInCanda = true;
        }

        internal override void Process()
        {
           
        }
    }
}