using System;

namespace EventSourcingDemo.Events
{
    public abstract class DomainEvent
    {
        private DateTime _recorded, _occurred;

        internal DomainEvent(DateTime occurred)
        {
            _occurred = occurred;
            _recorded = DateTime.Now;
        }

        internal abstract void Process();
        internal abstract void Reverse();
    }
}