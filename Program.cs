//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DataAccess;
using TravelAgencies.Descrambling;
using TravelAgencies.Interfaces;
using TravelAgencies.Decorators;
using TravelAgencies.Advertising_Agency;
using TravelAgencies.TravelAgencies;
using TravelAgencies.Offer_Websites;

namespace TravelAgencies
{
    class Program
    {
        static void Main(string[] args) { new Program().Run(); }

        private const int WebsitePermanentOfferCount = 2;
        private const int WebsiteTemporaryOfferCount = 3;
        private Random rd = new Random(257);

        //----------
        //YOUR CODE - additional fileds/properties/methods
        //----------

        public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            (
                BookingDatabase accomodationData,
                TripAdvisorDatabase tripsData,
                ShutterStockDatabase photosData,
                OysterDatabase reviewData
            ) = Init.Init.Run();


         
            //----------
            //YOUR CODE - set up everything
            ITravelAgency polandTravelAgency = new PolandTravel(new TravelAgency(accomodationData, reviewData, photosData, tripsData), tripsData);
            ITravelAgency italyTravelAgency = new ItalyTravel(new TravelAgency(accomodationData, reviewData, photosData, tripsData), tripsData);
            ITravelAgency franceTravelAgency = new FranceTravel(new TravelAgency(accomodationData, reviewData, photosData, tripsData), tripsData);
            Random random = new Random();
            //----------

            while (true)
            {
                Console.Clear();

                //----------
                //YOUR CODE - run
                IAdvertisingAgency textAdvertisingAgency = new TextAdvertisingAgency();
                textAdvertisingAgency.CreateOffer(polandTravelAgency, 2, true, random.Next(1,5));
                textAdvertisingAgency.CreateOffer(italyTravelAgency, 3, false, -1);
                textAdvertisingAgency.CreateOffer(franceTravelAgency, 2, true, random.Next(1, 5));
                IAdvertisingAgency graphicalAdvertisingAgency = new GraphicalAdvertisingAgency();
                graphicalAdvertisingAgency.CreateOffer(polandTravelAgency, 2, false, -1);
                graphicalAdvertisingAgency.CreateOffer(italyTravelAgency, 2, true, random.Next(1, 5));
                graphicalAdvertisingAgency.CreateOffer(franceTravelAgency, 2, true, random.Next(1, 5));

                IOfferWebsite offerWebsite = new OfferWebsite();
                offerWebsite.AddAgency(textAdvertisingAgency);
                offerWebsite.AddAgency(graphicalAdvertisingAgency);
                //----------

                //uncomment
                Console.WriteLine("\n\n=======================FIRST PRESENT======================");
                offerWebsite.Present();
                Console.WriteLine("\n\n=======================SECOND PRESENT======================");
                offerWebsite.Present();
                Console.WriteLine("\n\n=======================THIRD PRESENT======================");
                offerWebsite.Present();


                if (HandleInput()) break;
            }
        }
        bool HandleInput()
        {
            var key = Console.ReadKey(true);
            return key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q;
        }
    }
}
