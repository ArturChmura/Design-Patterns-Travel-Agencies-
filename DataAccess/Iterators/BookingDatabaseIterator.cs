//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using System;
using TravelAgencies.Concrete;
using TravelAgencies.Interfaces;

namespace TravelAgencies.DataAccess
{
    class BookingDatabaseIterator: IDatabaseIterator<IAccomodation>
	{
		BookingDatabase database;
		ListNode[] currentRooms;

		int indexRooms = 0;

		public BookingDatabaseIterator(BookingDatabase database)
		{
			this.database = database;
			currentRooms = (ListNode[])database.Rooms.Clone();
		}


		public IAccomodation GetCurrent()
		{
			return new Hotel(currentRooms[indexRooms].Name, currentRooms[indexRooms].Price, currentRooms[indexRooms].Rating);
		}

		public void Reset()
		{
			indexRooms = -1;
		}
		bool HasNextNode(ListNode listNode)
		{
			if (listNode.Next != null) return true;
			return false;

		}
		public bool HasNext()
		{
			indexRooms = (indexRooms + 1) % database.Rooms.Length;
			int end = indexRooms;
			do
			{
				if (HasNextNode(currentRooms[indexRooms])) return true;
				indexRooms = (indexRooms + 1) % database.Rooms.Length;
			} while (indexRooms != end);
			return false;
		}
	}
}
