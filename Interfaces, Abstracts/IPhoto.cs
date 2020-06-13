//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using System;
using TravelAgencies.DataAccess;

using TravelAgencies.Descrambling;
namespace TravelAgencies.Interfaces
{
    public interface IPhoto
    {
        string Name { get; }
        string WidthPx { get; set; }//Encrypted
        string HeightPx { get; set; }//Encrypted
        double Longitude { get; }
        double Latitude { get; }
        string Camera { get;  }
        double[] CameraSettings { get;  }
        DateTime Date { get;  }
      
        string ToString();
    }
}