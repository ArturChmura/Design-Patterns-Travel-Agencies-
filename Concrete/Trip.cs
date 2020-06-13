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
    class Trip : ITrip
    {
        public int DaysCount { get; set; }
        public List<List<IAttraction>> Attractions { get; set; }
        public List<IAccomodation> Hotels { get; set; }

        public string Country { get; set; }

        public double Rating
        {
            get
            {
                double sum = 0.0;
                int count = 0;
                foreach (List<IAttraction> attractions in Attractions)
                {
                    foreach (Attraction attraction in attractions)
                    {
                        sum += double.Parse(attraction.Rating);
                        count++;
                    }
                }
                foreach (IAccomodation hotel in Hotels)
                {
                    sum += double.Parse(hotel.Rating);
                    count++;
                }
                return sum / count;
            }
        }

        public double Price
        {
            get
            {
                double sum = 0.0;
                foreach (List<IAttraction> attractions in Attractions)
                {
                    foreach (IAttraction attraction in attractions)
                    {
                        sum += double.Parse(attraction.Price);
                    }
                }
                foreach (IAccomodation hotel in Hotels)
                {
                    sum += double.Parse(hotel.Price);;
                }
                return sum ;
            }
        }

        public Trip(int daysCount, string country = "")
        {
            DaysCount = daysCount;
            Attractions = new List<List<IAttraction>>(daysCount);
            for (int i = 0; i < daysCount; i++)
            {
                Attractions.Add(new List<IAttraction>());
                Attractions[i] = new List<IAttraction>(3);
            }
            Hotels = new List<IAccomodation>(daysCount);
            Country = country;
        }
    }
}
