// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using static System.Net.Mime.MediaTypeNames;

//Plane plane1 = new Plane();
//plane1.Capacity = 100;
//plane1.ManufactureDate = new DateTime(2024, 05, 23);
//plane1.PlaneType=PlaneType.Airbus;
//plane1.PlaneId = 1;
//Console.WriteLine(plane1.ToString());
//Plane plane2=new Plane(PlaneType.Airbus,200,DateTime.Now);
//Console.WriteLine(plane2.ToString());

//Plane plane3 = new Plane
//{
//    Capacity = 100,
//    PlaneId = 3,
//    PlaneType = 0,
//};

//Console.WriteLine(plane3.ToString());
//Plane plane4 = new Plane();
//Console.WriteLine(plane4.ToString());
//Passenger passenger = new Passenger
//{
//    FirstName = "Arij",
//    LastName = "Moulehi",
//    EmailAddress = "arij.moulehi@esprit.tn",
//};
//Console.WriteLine(passenger.ToString());
//Console.WriteLine(passenger.CheckProfile("Arij","Moulehi", "arij.moulehi@esprit.tn"));
//Console.WriteLine(passenger.CheckProfile("Arijj", "Moulehi", "arij.moulehi@esprit.tn"));
//Console.WriteLine(passenger.CheckProfile("Arijj", "Moulehi"));
//Staff staff1 = new Staff
//{
//    FirstName="arij",
//    LastName="moulahi"
//};
//Traveller traveller1 = new Traveller
//{
//    Nationality = "Tunisian",
//    FirstName = "arij"
//};

//passenger.PassengerType();
//staff1.PassengerType();
//traveller1.PassengerType();

/****atelier2******/

FlightMethods flightMethods = new FlightMethods
{
    Flights = TestData.listFlights
};

//foreach (var flight in flightMethods.GetFlightDates("Paris"))
//{
//    Console.WriteLine(flight);
//}

//question8
flightMethods.GetFlights("Destination", "Paris");

//question10
flightMethods.ShowFlightDetails(TestData.BoingPlane);

//question11
Console.WriteLine(flightMethods.ProgrammedFlightNumber(new DateTime(2022, 02, 01, 21, 10, 10)));

//question12
Console.WriteLine(flightMethods.DurationAverage("Madrid"));

//question13
Console.WriteLine("Ordered flights:");
foreach (var flight in flightMethods.OrderedDurationFlights())
{
    Console.WriteLine(flight);
}

//question14
var seniorTravellers = flightMethods.SeniorTravellers(TestData.flight1);
Console.WriteLine("Senior Travellers:");
foreach (var traveller in seniorTravellers)
{
    Console.WriteLine($"{traveller.FirstName} {traveller.LastName} - {traveller.BirthDate:dd/MM/yyyy}");
}

//question15
Console.WriteLine("\nGrouped Flights by Destination:");
flightMethods.DestinationGroupedFlights();
Console.WriteLine("\n Grouped Flights by Destination 2:");
flightMethods.DestinationGroupedFlights2();

//DestinationGroupedFlights2 methode o5ra :)
Console.WriteLine("Testing DestinationGroupedFlights2:");
var groupedFlights = flightMethods.DestinationGroupedFlights2();
foreach (var group in groupedFlights)
{
    if (group.Count > 0)
    {
        Console.WriteLine($"Destination {group[0].Destination}");
        foreach (var flight in group)
        {
            Console.WriteLine($"Décollage : {flight.FlightDate:dd/MM/yyyy HH:mm:ss}");
        }
    }
}
Console.WriteLine();


flightMethods.ShowFlightDetails(TestData.Airbusplane);
flightMethods.FlightDetailsDel(TestData.Airbusplane);


//test extension
Console.WriteLine("test extension");
Passenger passenger = new Passenger
{
    FirstName = "arij",
    LastName = "moulehi",
    EmailAddress = "arij.moulehi@esprit.tn",
};
Console.WriteLine(passenger.ToString());
passenger.UpperFullName();
Console.WriteLine(passenger.ToString());