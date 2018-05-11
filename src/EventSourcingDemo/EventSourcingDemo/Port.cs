using EventSourcingDemo.Enums;

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

        public Country Country { get; set; }
    }
}