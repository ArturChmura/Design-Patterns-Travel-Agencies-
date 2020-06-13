//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Interfaces;

namespace TravelAgencies.Offer_Websites
{
    class OfferWebsite : IOfferWebsite
    {

        List<IAdvertisingAgency> Agencies;
        public OfferWebsite()
        {
            Agencies = new List<IAdvertisingAgency>();
        }

        public void AddAgency(IAdvertisingAgency agency)
        {
            Agencies.Add(agency);
        }

        public void Present()
        {
            foreach (IAdvertisingAgency agency in Agencies)
            {
                Console.WriteLine(agency.GetAllOffers());
            }
        }
    }
}
