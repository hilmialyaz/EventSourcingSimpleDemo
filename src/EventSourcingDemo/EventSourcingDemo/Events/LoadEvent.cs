using System;

namespace EventSourcingDemo.Events
{
    public class LoadEvent :DomainEvent
    {
        public LoadEvent(DateTime dateTime, Cargo refact, Ship kr) : base(dateTime)
        {
           
        }

        internal override void Process()
        {
           
        }
    }
}