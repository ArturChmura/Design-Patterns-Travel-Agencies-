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

    class Hotel : IAccomodation
    {
        public string Name { get; }
        public string Price { get; set; }
        public string Rating { get; set; }


        public Hotel(string name, string price, string rating)
        {
            Name = name;
            Price = price;
            Rating = rating;
        }
        public Hotel()
        {
            Name = "No Hotel";
            Price = "0";
            Rating = "0";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
