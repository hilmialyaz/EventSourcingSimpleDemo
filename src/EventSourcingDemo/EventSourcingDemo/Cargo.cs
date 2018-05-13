using EventSourcingDemo.Enums;
using EventSourcingDemo.Events;

namespace EventSourcingDemo
{
    public class Cargo
    {
        private Port _port;
        private Ship _ship;

        public Cargo(string refactoring)
        {
            
        }

        private bool _hasBeenInCanada = false;
        private object declaredValue;
        public bool HasBeenInCanda { get { return _hasBeenInCanada; } }
        public object RegistrationCode { get; set; }

        public void HandleArrival(ArrivalEvent ev)
        {
            ev.priorCargoInCanada[this] = _hasBeenInCanada;
            if ("CA" == ev.Port.Country)
                _hasBeenInCanada = true;
             declaredValue = Registry.PricingGateway.GetPrice(this);
        }

        public void HandleLoad(LoadEvent loadEvent)
        {
            loadEvent.priorPort = _port;
            _port = null;
            _ship = loadEvent.Ship;
            _ship.HandleLoad(loadEvent);
        }

        public void ReverseLoad(LoadEvent loadEvent)
        {
            _ship.ReverseLoad(loadEvent);
            _ship = null;
            _port = loadEvent.priorPort;
        }

        public Cargo Find(string cargoCode)
        {
            return new Cargo(cargoCode);
        }

        public void ReverserArrival(ArrivalEvent ev)
        {
            _hasBeenInCanada = (bool) ev.priorCargoInCanada[this];
        }
    }
}