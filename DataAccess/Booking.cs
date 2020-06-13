//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Interfaces;
using TravelAgencies.Concrete;

namespace TravelAgencies.DataAccess
{
	class ListNode
	{
		public ListNode Next { get; set; }
		public string Name { get; set; }
		public string Rating { get; set; }//Encrypted
		public string Price { get; set; }//Encrypted
	}
	class BookingDatabase :IDatabase<IAccomodation>
	{
		public ListNode[] Rooms { get; set; }

		public IDatabaseIterator<IAccomodation> GetIterator()
		{
			return new BookingDatabaseIterator(this);
		}
	}
}
