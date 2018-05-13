namespace EventSourcingDemo.Events
{
    public class QueryEvent
    {
        private DomainEvent _eventBeingProcessed;
        private object result;

        public QueryEvent()
        {
            _eventBeingProcessed = Registry.EventProcessor.CurrentEvent;
        }

        public object Result
        {
            get { return result; }
            set { result = value; }
        }

        public DomainEvent EventBeingProcessed
        {
            get { return _eventBeingProcessed; }
        }
    }
}