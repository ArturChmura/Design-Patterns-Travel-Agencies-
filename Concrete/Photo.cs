//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using System;
using TravelAgencies.Interfaces;
namespace TravelAgencies.Concrete
{
    class Photo : IPhoto
    {
        public string Name { get; }

        public string WidthPx { get; set; }

        public string HeightPx { get; set; }

        public double Longitude { get;  }

        public double Latitude { get; }
        public string Camera { get; }
        public double[] CameraSettings { get;  }
        public DateTime Date { get;  }
        public Photo(string name,string widthPx,string heightPx,double longitude,double latitide,string camera,  double[] cameraSettings,DateTime date)
        {
            Name = name;
            WidthPx = widthPx;
            HeightPx = heightPx;
            Longitude = longitude;
            Latitude = latitide;
            Camera = camera;
            CameraSettings = (double[])cameraSettings.Clone();
            Date = date;

        }
        public Photo()
        {
            Name = "No Photo";
            WidthPx = "0";
            HeightPx = "0";
            Longitude = -1;
            Latitude = -1;
            Camera = "NoN";
            CameraSettings = null ;
            Date = new DateTime();

        }
        public override string ToString()
        {
            return Name + " (" + WidthPx + "x" + HeightPx + ")"; 
        }
    }
}