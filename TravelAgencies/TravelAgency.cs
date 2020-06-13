//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using TravelAgencies.DataAccess;
using TravelAgencies.Descrambling;
using TravelAgencies.Concrete;
using TravelAgencies.Interfaces;

namespace TravelAgencies.TravelAgencies
{
    class TravelAgency : ITravelAgency
    {

        IDatabaseIterator<IAccomodation> bookingIterator;
        IDatabaseIterator<IReview> oysteIterator;
        IDatabaseIterator<IPhoto> stockIterator;
        IDatabaseIterator<IAttraction> tripAdvisorIterator;

        Descrambler bookingDescrambler;
        Descrambler stockDescrambler;
        Descrambler tripAdvisorDescrambler;

        public TravelAgency(IDatabase<IAccomodation> bookingDatabase, IDatabase<IReview> oysterDatabase, IDatabase<IPhoto> stockDatabase, IDatabase<IAttraction> tripAdvisorDatabase)
        {
            this.bookingIterator = bookingDatabase.GetIterator();
            this.oysteIterator = oysterDatabase.GetIterator(); ;
            this.stockIterator = stockDatabase.GetIterator(); ;
            this.tripAdvisorIterator = tripAdvisorDatabase.GetIterator();
            this.bookingDescrambler = new BookingDescramblerFactory().GetDescrambler();
            this.stockDescrambler = new ShutterStockDescramblerFactory().GetDescrambler();
            this.tripAdvisorDescrambler = new TripAdvisorDescramblerFactory().GetDescrambler();
        }
        public IPhoto CreatePhoto()
        {
            IPhoto photo;
            if (stockIterator.HasNext())
            {
                photo = stockIterator.GetCurrent();
            }
            else
            {
                stockIterator.Reset();
                if (!stockIterator.HasNext())
                {
                    return new Photo();
                }
                photo =  stockIterator.GetCurrent();
            }
            photo.WidthPx = stockDescrambler.Handle(photo.WidthPx);
            photo.HeightPx = stockDescrambler.Handle(photo.HeightPx);
            return photo;
        }

        public IReview CreateReview()
        {
            if (oysteIterator.HasNext())
            {
                return oysteIterator.GetCurrent();
            }

            oysteIterator.Reset();
            if (!oysteIterator.HasNext())
            {
                return new Review();
            }
            return oysteIterator.GetCurrent();



        }

        public ITrip CreateTrip()
        {
            Random random = new Random();
            IAccomodation hotel;
            ITrip trip = new Trip(random.Next(1, 5));
            for (int i = 0; i < trip.DaysCount; i++)
            {
                if (bookingIterator.HasNext())
                {
                    hotel = bookingIterator.GetCurrent();
                }
                else
                {
                    bookingIterator.Reset();
                    if (!bookingIterator.HasNext())
                    {
                        trip.Hotels.Add(new Hotel());
                        continue;
                    }
                    hotel = bookingIterator.GetCurrent();
                }


                hotel.Price = bookingDescrambler.Handle(hotel.Price);
                hotel.Rating = bookingDescrambler.Handle(hotel.Rating);
                trip.Hotels.Add(hotel);

            }

            return trip;
        }
    }
}