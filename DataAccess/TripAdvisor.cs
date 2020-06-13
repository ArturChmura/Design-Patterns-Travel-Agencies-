//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Interfaces;
using TravelAgencies.Concrete;

namespace TravelAgencies.DataAccess
{
	class TripAdvisorDatabase :IDatabase<IAttraction>
	{
		public Guid[] Ids;
		public Dictionary<Guid, string>[] Names { get; set; }
		public Dictionary<Guid, string> Prices { get; set; }//Encrypted
		public Dictionary<Guid, string> Ratings { get; set; }//Encrypted
		public Dictionary<Guid, string> Countries { get; set; }



		public IDatabaseIterator<IAttraction> GetIterator()
		{
			return new TripAdvisorDatabaseIterator(this);
		}
	}
}

