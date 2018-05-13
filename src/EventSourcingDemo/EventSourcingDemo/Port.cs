using System;
using System.Collections;
using System.Dynamic;
using EventSourcingDemo.Enums;
using EventSourcingDemo.Events;
using EventSourcingDemo.Gateway;

namespace EventSourcingDemo
{
    public class Port
    {
        private string v;
        private Country uS;
        public static Port AT_SEA;

        public Port(string v, Country uS)
        {
            this.v = v;
            this.uS = uS;
        }

        public string Country{ get; set; }

        public void HandleArrival(ArrivalEvent ev)
        {
            ev.Ship.Port = this;
            Registry.CustomsNotificationGateway.Notify(ev.Occurred, ev.Ship, ev.Port);
        }
    }

    public class Registry
    {
        public static CustomsNotificationGateway CustomsNotificationGateway { get; set; }

        public class PricingGateway
        {
            public static object GetPrice(Cargo cargo)
            {
                return cargo.HasBeenInCanda;
            }
        }

        class LoggedPricingGateway
        {
            private interface IIlog
            {
                void Store(GetPriceRequest request);
                IList FindBy(DomainEvent currentEvent, Type type);
            }

            private IIlog log;

            private object newRequest(Cargo cargo)
            {
                GetPriceRequest request = new GetPriceRequest(cargo);
                request.Result = new GetPriceRequest(cargo);
                log.Store(request);
                return request.Result;
            }

            private GetPriceRequest oldRequest(Cargo cargo)
            {
                IList candidates =
                    log.FindBy(EventProcessor.CurrentEvent, typeof(GetPriceRequest));
                foreach (GetPriceRequest request in candidates)
                {
                    if (request.Cargo.RegistrationCode == cargo.RegistrationCode)
                        return request;
                }

                return null;
            }
        }

        public class EventProcessor
        {
            public static DomainEvent CurrentEvent { get; set; }
        }
    }

    internal class GetPriceRequest : QueryEvent
    {
        private Cargo cargo;
        public GetPriceRequest(Cargo cargo) : base()
        {
            this.cargo = cargo;
        }

        public Cargo Cargo { get; set; }
    }
}