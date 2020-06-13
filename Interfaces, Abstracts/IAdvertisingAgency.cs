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

namespace TravelAgencies.Interfaces
{
	interface IAdvertisingAgency
	{
		List<IOffer> Offers { get; }
		void CreateOffer(ITravelAgency travelAgency,int descriptionsCount, bool timed, int expireTime);

		string GetAllOffers();
	}
	
}