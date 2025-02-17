using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string Telnumber { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "FirstName=" + this.FirstName + "LastName=" + this.LastName;
        }
        //public bool CheckProfile(string firstname,string lastname)
        //{
        //    return this.FirstName==firstname && this.LastName==lastname;
        //}
        public bool CheckProfile(string firstname, string lastname, string email = null)
        {
            if (email == null)
            {
                return firstname== lastname &&lastname==lastname;
            }
            else
            {
                return this.FirstName == firstname && this.LastName == lastname && EmailAddress == EmailAddress;
            }
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
