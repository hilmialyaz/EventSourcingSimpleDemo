using System;
using NUnit.Framework;

namespace EventSourcingDemo.Test
{
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
           
        }
    }
}
