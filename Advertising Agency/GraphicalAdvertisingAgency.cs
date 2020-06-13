//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Concrete;
using TravelAgencies.Interfaces;

namespace TravelAgencies.Advertising_Agency
{
    class GraphicalAdvertisingAgency : IAdvertisingAgency
    {

        public List<IOffer> Offers { get; }
        public GraphicalAdvertisingAgency()
        {
            Offers = new List<IOffer>();
        }
        public void CreateOffer(ITravelAgency travelAgency, int descriptionsCount, bool timed, int expireTime)
        {
            ITrip trip = travelAgency.CreateTrip();
            IPhoto[] photos = new IPhoto[descriptionsCount];
            for (int i = 0; i < descriptionsCount; i++)
            {
                photos[i] = travelAgency.CreatePhoto();
            }

            Offers.Add(new GraphicsOffer(trip, photos, timed, expireTime));
        }

        public string GetAllOffers()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IOffer offer in Offers)
            {
                sb.Append(offer.Present());
            }
            return sb.ToString();
        }
    }
}
