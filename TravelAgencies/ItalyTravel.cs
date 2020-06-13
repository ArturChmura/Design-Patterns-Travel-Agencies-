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
using TravelAgencies.Concrete;


namespace TravelAgencies.TravelAgencies
{

    class ItalyTravel : ITravelAgency
    {
        ITravelAgency travelAgency;
        IDatabaseIterator<IAttraction> tripAdvisorIterator;
        Descrambler tripAdvisorDescrambler;
        public ItalyTravel(ITravelAgency travelAgency, IDatabase<IAttraction> tripAdvisorDatabase)
        {
            this.travelAgency = travelAgency;
            this.tripAdvisorIterator = tripAdvisorDatabase.GetIterator();
            this.tripAdvisorDescrambler = new TripAdvisorDescramblerFactory().GetDescrambler();
        }
        public IPhoto CreatePhoto()
        {
            IPhoto photo = travelAgency.CreatePhoto();
            while (photo.Longitude < 8.8 || photo.Longitude > 15.2 || photo.Latitude < 37.7 || photo.Latitude > 44.0)
            {
                photo = travelAgency.CreatePhoto();
            }
            return new ItalyPhotoDecorator(photo);
        }

        public IReview CreateReview()
        {
            return new ItalyReviewDecorator(travelAgency.CreateReview());
        }

        public ITrip CreateTrip()
        {

            ITrip trip = travelAgency.CreateTrip();
            trip.Country = "Italy";
            IAttraction attraction;
            for (int i = 0; i < trip.DaysCount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    do
                    {
                        if (tripAdvisorIterator.HasNext())
                        {
                            attraction = tripAdvisorIterator.GetCurrent(); 
                            attraction.Rating = tripAdvisorDescrambler.Handle(attraction.Rating);
                            attraction.Price = tripAdvisorDescrambler.Handle(attraction.Price);
                        }
                        else
                        {
                            tripAdvisorIterator.Reset();
                            if (!tripAdvisorIterator.HasNext())
                            {
                                attraction = new Attraction();
                                break;
                            }
                            attraction = tripAdvisorIterator.GetCurrent();
                            attraction.Rating = tripAdvisorDescrambler.Handle(attraction.Rating);
                            attraction.Price = tripAdvisorDescrambler.Handle(attraction.Price);
                        }
                    } while (attraction.Country != "Italy");
                    trip.Attractions[i].Add(attraction);
                }
            }
            return trip;

        }
    }
}