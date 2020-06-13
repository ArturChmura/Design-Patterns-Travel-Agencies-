//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using TravelAgencies.Concrete;
using TravelAgencies.Interfaces;

namespace TravelAgencies.DataAccess
{
    class ShutterStockDatabaseIterator : IDatabaseIterator<IPhoto>
    {
        ShutterStockDatabase database;
        int i1;
        int i2;
        int i3;
        public ShutterStockDatabaseIterator(ShutterStockDatabase database)
        {
            this.database = database;
            i1 = 0;
            i2 = 0;
            i3 = -1;
        }

        bool HasNextSecLvl()
        {
            if (database.Photos[i1] == null)
            {
                i2 = 0;
                return false;
            }
            while (i2 < database.Photos[i1].Length)
            {
                if (HasNextThirdLvl())
                {
                    return true;
                }
                i2++;
            }
            i2 = 0;
            return false;

        }
        bool HasNextThirdLvl()
        {
            if (database.Photos[i1][i2] == null)
            {
                i3 = -1;
                return false;
            }
            i3++;
            while (i3 < database.Photos[i1][i2].Length)
            {
                if (database.Photos[i1][i2][i3] != null)
                {
                    return true;
                }
                i3++;
            }
            i3 = -1;
            return false;
        }
        public void Reset()
        {
            i1 = i2 = 0;
            i3 = -1;
        }
        public IPhoto GetCurrent()
        {
            PhotMetadata meta = database.Photos[i1][i2][i3];
            return new Photo(meta.Name, meta.WidthPx, meta.HeightPx, meta.Longitude, meta.Latitude, meta.Camera, meta.CameraSettings, meta.Date);
        }

        public bool HasNext()
        {
            while (i1 < database.Photos.Length)
            {
                if (HasNextSecLvl()) return true;
                i1++;
            }
            return false;
        }
    }
}
