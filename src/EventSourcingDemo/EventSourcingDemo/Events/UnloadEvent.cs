using System;

namespace EventSourcingDemo.Events
{
    public class UnloadEvent:DomainEvent
    {
        public UnloadEvent(DateTime dateTime, Cargo refact, Ship kr):base(dateTime)
        {
          
        }

        internal override void Process()
        {
           
        }

        internal override void Reverse()
        {
           
        }
    }
}