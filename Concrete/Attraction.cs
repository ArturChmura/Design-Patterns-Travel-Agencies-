//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Interfaces;

namespace TravelAgencies.Concrete
{
    class Attraction:IAttraction
    {
        public string Name { get; }
        public string Price { get; set; }
        public string Rating { get; set; }
        public string Country { get; }


        public Attraction(string name, string price, string rating, string country)
        {
            Name = name;
            Price = price;
            Rating = rating;
            Country = country;
        }
        public Attraction()
        {
            Name = "No Attraction";
            Price = "0";
            Rating = "0";
            Country = "NoNe";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
