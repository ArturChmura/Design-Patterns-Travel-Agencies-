//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using TravelAgencies.Concrete;
using TravelAgencies.Decorators;
using TravelAgencies.Descrambling;
using TravelAgencies.Interfaces;


namespace TravelAgencies.TravelAgencies
{

    class FranceTravel : ITravelAgency
    {
        ITravelAgency travelAgency;
        IDatabaseIterator<IAttraction> tripAdvisorIterator;
        Descrambler tripAdvisorDescrambler;
        public FranceTravel(ITravelAgency travelAgency, IDatabase<IAttraction> tripAdvisorDatabase)
        {
            this.travelAgency = travelAgency;
            this.tripAdvisorIterator = tripAdvisorDatabase.GetIterator();
            this.tripAdvisorDescrambler = new TripAdvisorDescramblerFactory().GetDescrambler();
        }
        public IPhoto CreatePhoto()
        {
            IPhoto photo = travelAgency.CreatePhoto();
            while (photo.Longitude < 0.0 || photo.Longitude > 5.4|| photo.Latitude < 43.6 || photo.Latitude > 50.0)
            {
                photo = travelAgency.CreatePhoto();
            }
            return photo;
        }

        public IReview CreateReview()
        {
            return new FranceReviewDecorator(travelAgency.CreateReview());
        }

        public ITrip CreateTrip()
        {
            ITrip trip = travelAgency.CreateTrip();
            trip.Country = "France";
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
                    } while (attraction.Country != "France");
                    trip.Attractions[i].Add(attraction);
                }
            }
            return trip;

        }
    }
}