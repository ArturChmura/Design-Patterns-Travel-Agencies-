//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using TravelAgencies.Concrete;
using TravelAgencies.Interfaces;

namespace TravelAgencies.DataAccess
{
    class TripAdvisorDatabaseIterator : IDatabaseIterator<IAttraction>
    {
        int index = 0;
        string name;
        string price;
        string rating;
        string country;
        TripAdvisorDatabase database;
        public TripAdvisorDatabaseIterator(TripAdvisorDatabase database)
        {
            this.database = database;
        }
       
        bool ContainName(Guid id)
        {
            for (int i = 0; i < database.Names.Length; i++)
            {
                if (database.Names[i].TryGetValue(id,out name))
                {
                    return true;
                }
            }
            return false;
        }
        public IAttraction GetCurrent()
        {
            return new Attraction(name, price, rating, country); ;
        }

        public void Reset()
        {
            index = -1;
        }

        public bool HasNext()
        {
            index++;
            if (index == database.Ids.Length) return false;
            Guid id = database.Ids[index];
            while (!ContainName(id) || !database.Prices.TryGetValue(id,out price) || !database.Ratings.TryGetValue(id, out rating) || !database.Countries.TryGetValue(id, out country))
            {
                index++;
                if (index == database.Ids.Length) return false;
                id = database.Ids[index];
            }
            return true;
        }
    }
}

