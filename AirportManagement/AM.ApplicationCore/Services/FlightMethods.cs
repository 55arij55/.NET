using System.Linq.Expressions;
using System.Numerics;
using System.Text.RegularExpressions;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight> { };

        //question16
        public Action<Domain.Plane> FlightDetailsDel;
        public Func<String, float> DurationAverageDel;

        public FlightMethods()
        {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            DurationAverageDel =d => {
                var query = from flight in Flights
                            where flight.Destination == d
                            select flight.EstimatedDuration;
                return query.Average();
            };
            
            FlightDetailsDel =p => {
                var query = from f in Flights
                            where f.MyPlane == p
                            select f;
                foreach (var f in query)
                {
                    Console.WriteLine(f.ToString());
                }
            };
        }

        public void DestinationGroupedFlights()
        {
            //var query = Flights
            //    .GroupBy(f => f.Destination)
            //    .ToList();
            //foreach (var group in query) { 
            //    Console.WriteLine($"Destination {group.Key}");
            //    foreach (var flight in group)
            //    {
            //        Console.WriteLine($"Décollage : {flight.FlightDate:dd/MM/yyyy HH:mm:ss}");
            //    }
            //}

            var lambdaquery = Flights
                .GroupBy(f => f.Destination);
            foreach (var group in lambdaquery)
            {
                Console.WriteLine($"Destination {group.Key}");
                foreach (var flight in group)
                {
                    Console.WriteLine($"Décollage : {flight.FlightDate:dd/MM/yyyy HH:mm:ss}");
                }
            }
        }

        public IList<List<Flight>> DestinationGroupedFlights2()
        {
            var groupedFlights = Flights
                .GroupBy(f => f.Destination)
                .Select(group => group.ToList())
                .ToList();
             return groupedFlights;
        }

        public float DurationAverage(string destination)
        {
            //var query = from flight in Flights
            //            where flight.Destination == destination
            //            select flight.EstimatedDuration;
            //return query.Average();

            //question19
            var lambdaquery = Flights
                .Where(f => f.Destination == destination)
                .Select (f => f.EstimatedDuration);
            return lambdaquery.Average();
        }

        public IList<DateTime> GetFlightDates(string destination)
        {
            IList<DateTime> dates = new List<DateTime>() { };
            //for (int i = 0; i < Flights.Count; i++)
            //{
            //    if (Flights[i].Destination.Equals(destination))
            //    {
            //        dates.Add(Flights[i].FlightDate);
            //    }
            //}
            //foreach (var flight in Flights)
            //{
            //    if (flight.Destination == destination) { 
            //    dates.Add(flight.FlightDate);
            //    }
            //}
            //return dates;

            //question9

            //var query =from f in Flights
            //           where f.Destination == destination
            //           select f.FlightDate;
            //return query.ToList();

            //question19
            var lambdaquery = Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate);
            return lambdaquery.ToList();

        }

        public void GetFlights(string filterType, string filterValue)
        {
                switch (filterType){
                    case "Destination":
                        foreach (var flight in Flights)
                        {
                        if (flight.Destination.Equals(filterType))
                            {
                                Console.WriteLine(flight.ToString()) ;
                            }
                        }break;
                    case "FlightDate":
                        foreach (var flight in Flights)
                        {
                            if (flight.FlightDate == DateTime.Parse(filterValue))
                            {
                                Console.WriteLine(flight.ToString());
                            }
                        }
                        break;
                    case "EstimatedDuration":
                        foreach (var flight in Flights)
                        {
                            if (flight.EstimatedDuration == float.Parse(filterValue))
                            {
                                Console.WriteLine(flight.ToString());
                            }
                        }
                        break;
                    case "Departure":
                        foreach (var flight in Flights)
                        {
                            if (flight.Departure == filterType)
                            {
                                Console.WriteLine(flight.ToString());
                            }
                        }
                        break;
                    case "EffectiveArrival":
                        foreach (var flight in Flights)
                        {
                            if (flight.EffectiveArrival == DateTime.Parse(filterType))
                            {
                                Console.WriteLine(flight.ToString());
                            }
                        }
                        break;
                }
            
        }

        public IList<Flight> OrderedDurationFlights()
        {
            //var query = from flight in Flights
            //            orderby flight.EstimatedDuration descending
            //           select flight;
            //return query.ToList();

            //question19
            var lambdaquery = Flights.OrderByDescending(f => f.EstimatedDuration);
            return lambdaquery.ToList();
            
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //meth1
            //var query = from flight in Flights
            //            where DateTime.Compare(flight.FlightDate, startDate) > 0
            //            && (flight.FlightDate - startDate).TotalDays<7
            //            select flight;
            //return query.Count();

            //meth2
            //var query = from flight in Flights
            //            where flight.FlightDate>= startDate
            //            && (flight.FlightDate < startDate.AddDays(7))
            //            select flight;
            //return query.Count();

            //question19
            var lambdaquery = Flights
                .Where(f => f.FlightDate == startDate && (f.FlightDate < startDate.AddDays(7)));
            return lambdaquery.Count();
        }

        public IList<Traveller> SeniorTravellers(Flight flight)
        {
            //var query = flight.ListPassengers
            //    .OfType<Traveller>()
            //    .OrderBy(t => t.BirthDate)
            //    .Take(3)
            //    .ToList();
            //return query;

            //question19
            var lambdaquery = flight
                .ListPassengers
                .OfType<Traveller>()
                .OrderBy(p=> p.BirthDate);
            return lambdaquery.ToList();
        }

        public void ShowFlightDetails(Domain.Plane plane)
        {
            //var query =from f in Flights
            //           where f.MyPlane == plane
            //           select f;
            //foreach (var f in query)
            //{
            //    Console.WriteLine(f.ToString());
            //}

            //question19
            var lambdaquery = Flights
                .Where(f => f.MyPlane == plane)
                .Select(f => f); //najmou na7iouha
            foreach (var f in lambdaquery)
            {
                Console.WriteLine(f.ToString());
            }
        }


    }
}
