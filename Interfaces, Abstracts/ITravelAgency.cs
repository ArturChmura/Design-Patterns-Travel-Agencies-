
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Decorators;
using TravelAgencies.Interfaces;

namespace TravelAgencies.Interfaces
{
    interface ITravelAgency
    {
        ITrip CreateTrip();
        IPhoto CreatePhoto();
        IReview CreateReview();
    }
}