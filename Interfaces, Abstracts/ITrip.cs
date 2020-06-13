//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Concrete;

namespace TravelAgencies.Interfaces
{
    interface ITrip
    {
         string Country { get; set; }
         int DaysCount { get; set; }
        double Rating { get; }
        double Price { get; }
        List<List<IAttraction>> Attractions { get; set; }
         List<IAccomodation> Hotels { get; set; }

    }
}
