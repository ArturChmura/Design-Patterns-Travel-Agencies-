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

    class Offer : IOffer
    {

        protected ITrip Trip { get; }

        public bool Timed { get; }

        public int ExpireTime { get; set; }


        public Offer(ITrip trip, bool timed, int expireTime)
        {
            Trip = trip;
            Timed = timed;
            ExpireTime = expireTime;
        }

        public string Present()
        {
            if (Timed && ExpireTime-- <= 0) return "\nThis offer is expired\n";
            StringBuilder sb = new StringBuilder();
            sb.Append("\nPrice: " + Trip.Price.ToString("n2") + "\n");
            sb.Append("Rating: " + Trip.Rating.ToString("n2") + "\n");

            for (int i = 1; i <= Trip.DaysCount; i++)
            {
                sb.Append($"Day {i} in {Trip.Country}!\n");
                sb.Append($"Accommodation: {Trip.Hotels[i-1]}\n");
                sb.Append($"Attractions:\n");
                foreach (Attraction attraction in Trip.Attractions[i - 1])
                {
                    sb.Append("\t" + attraction.ToString() + "\n");
                }
            }



            return sb.ToString();
        }
    }
    class TextOffer : IOffer
    {
        IOffer offer;
        protected List<IReview> Reviews { get; }

        public bool Timed { get { return offer.Timed; } }

        public int ExpireTime { get { return offer.ExpireTime; } set { offer.ExpireTime = value; } }

        public TextOffer(ITrip trip, IEnumerable<IReview> reviews, bool timed, int expireTime)
        {
            offer = new Offer(trip, timed, expireTime);
            Reviews = new List<IReview>(reviews);
        }
        public string Present()
        {
            if (Timed && ExpireTime <= 0) return "\nThis offer is expired\n"; ;
            StringBuilder sb = new StringBuilder();

            sb.Append(offer.Present());

            foreach (IReview review in Reviews)
            {
                sb.Append(review.Author + ": " + review.Text + "\n");
            }

            return sb.ToString();
        }


    }
    class GraphicsOffer : IOffer
    {
        List<IPhoto> Photos;
        IOffer offer;
        protected List<IReview> Reviews { get; }

        public bool Timed { get { return offer.Timed; } }

        public int ExpireTime { get { return offer.ExpireTime; } set { offer.ExpireTime = value; } }
        public GraphicsOffer(ITrip trip, IEnumerable<IPhoto> photos, bool timed, int expireTime)
        {
            offer = new Offer(trip, timed, expireTime);
            Photos = new List<IPhoto>(photos);

        }

        public string Present()
        {
            if (Timed && ExpireTime <= 0) return "\nThis offer is expired\n"; ;
            StringBuilder sb = new StringBuilder();

            sb.Append(offer.Present());

            foreach (IPhoto photo in Photos)
            {
                sb.Append(photo.ToString() + "\n");
            }

            return sb.ToString();
        }

    }
}
