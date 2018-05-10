using System;

namespace EventSourcingDemo.Events
{
    public class ArrivalEvent
    {
        public ArrivalEvent(DateTime dateTime, Port sfo, Ship kr)
        {
            kr.Port = sfo;
        }
    }
}