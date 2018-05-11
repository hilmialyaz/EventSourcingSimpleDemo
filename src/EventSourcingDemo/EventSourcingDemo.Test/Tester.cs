using System;
using EventSourcingDemo.Enums;
using EventSourcingDemo.Events;
using NUnit.Framework;

namespace EventSourcingDemo.Test
{
    [TestFixture]
    public class Tester
    {
        private Ship kr;
        private Port sfo, la, yyv;
        private Cargo refact;
        private EventProcessor eProc;

        [SetUp]
        public void SetUp()
        {
           eProc = new EventProcessor();
           refact = new Cargo("Refactoring");
           kr = new Ship("King Roy");
           sfo = new Port("San Francisco",Country.US);
           la = new Port("Los Angeles",Country.US);
           yyv = new Port("Vancouver",Country.CANADA);
        }

        [Test]
        public void ArrivalSetsShipsLocation()
        {
           ArrivalEvent ev = new ArrivalEvent(new DateTime(2005,11,1),sfo,kr);
            eProc.Process(ev);
            Assert.AreEqual(sfo,kr.Port);
        }

        [Test]
        public void DeparturePutsShipOutToSea()
        {
            eProc.Process(new ArrivalEvent(new DateTime(2005,10,1),la,kr));
            eProc.Process(new ArrivalEvent(new DateTime(2005,11,1),sfo,kr));
            eProc.Process(new DepartureEvent(new DateTime(2005,11,1),sfo,kr));
            Assert.AreEqual(Port.AT_SEA,kr.Port);
        }

        [Test]
        public void VisitingCanadaMarksCargo()
        {
          eProc.Process(new LoadEvent(new DateTime(2005,11,1),refact,kr));
          eProc.Process(new ArrivalEvent(new DateTime(2005,11,2),yyv,kr));
          eProc.Process(new DepartureEvent(new DateTime(2005,11,3),yyv,kr));
          eProc.Process(new ArrivalEvent(new DateTime(2005,11,4),sfo,kr));
          eProc.Process(new UnloadEvent(new DateTime(2005,11,5),refact,kr));
          Assert.IsTrue(refact.HasBeenInCanda);
        }
    }
}
