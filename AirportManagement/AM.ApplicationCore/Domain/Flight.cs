using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public String Departure { get; set; }
        public String Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public Plane MyPlane { get; set; }
        public ICollection<Passenger> ListPassengers { get; set; }
        public override string ToString()
        {
            return "FlightID=" + this.FlightId + "Destination=" + this.Destination;
        }
    }
}
