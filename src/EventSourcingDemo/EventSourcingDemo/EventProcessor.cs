using System;
using System.Collections;
using EventSourcingDemo.Events;

namespace EventSourcingDemo
{
    public class EventProcessor
    {
        IList log = new ArrayList();
        public void Process(ArrivalEvent ev)
        {
            throw new NotImplementedException();
        }

        public void Process(DomainEvent e)
        {
            e.Process();
            log.Add(e);
        }
    }
}
