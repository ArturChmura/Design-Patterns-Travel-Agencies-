//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using TravelAgencies.Concrete;
using TravelAgencies.Decorators;
using TravelAgencies.Descrambling;
using TravelAgencies.Interfaces;


namespace TravelAgencies.TravelAgencies
{

    class PolandTravel : ITravelAgency
    {
        ITravelAgency travelAgency;
        IDatabaseIterator<IAttraction> tripAdvisorIterator;
        Descrambler tripAdvisorDescrambler;
        public PolandTravel(ITravelAgency travelAgency, IDatabase<IAttraction> tripAdvisorDatabase)
        {
            this.travelAgency = travelAgency;
            this.tripAdvisorIterator = tripAdvisorDatabase.GetIterator();
            this.tripAdvisorDescrambler = new TripAdvisorDescramblerFactory().GetDescrambler();
        }
        public IPhoto CreatePhoto()
        {
            IPhoto photo = travelAgency.CreatePhoto();
            while (photo.Longitude < 14.4 ||photo.Longitude > 23.5 ||  photo.Latitude < 49.8 || photo.Latitude > 54.2)
            {
                photo = travelAgency.CreatePhoto();
            }
            return new PolishPhotoDecorator(photo);
        }

        public IReview CreateReview()
        {
            
            return new PolishReviewDecorator(travelAgency.CreateReview());
        }

        public ITrip CreateTrip()
        {

            ITrip trip = travelAgency.CreateTrip();
            trip.Country = "Poland";
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
                    } while (attraction.Country != "Poland");

                    
                    trip.Attractions[i].Add(attraction);
                }
            }
            return trip;

        }
    }
}