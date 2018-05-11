using System;

namespace EventSourcingDemo.Gateway
{
    public class CustomsNotificationGateway
    {
        private EventProcessor processor;
        public void Notify(DateTime evOccurred, Ship evShip, Port evPort)
        {
            if (processor.isActive)
                SendToCustoms(BuildArrivalMessage(evOccurred, evShip, evPort));
        }

        private object BuildArrivalMessage(DateTime evOccurred, Ship evShip, Port evPort)
        {
            return evOccurred;
        }

        private void SendToCustoms(object buildArrivalMessage)
        {
            
        }
    }
}