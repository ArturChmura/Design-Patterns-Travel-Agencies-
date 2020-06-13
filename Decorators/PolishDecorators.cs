//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Interfaces;

namespace TravelAgencies.Decorators
{
    class PolishReviewDecorator : IReview
    {
        IReview review;
        public PolishReviewDecorator(IReview review)
        {
            this.review = review;
        }
        public string Text { get { return review.Text.Replace('e', 'ę').Replace('a', 'ą'); } }

        public string Author { get { return review.Author; } }
    }

    class PolishPhotoDecorator : IPhoto
    {
        IPhoto photo;
        public PolishPhotoDecorator(IPhoto photo)
        {
            this.photo = photo;
        }

        public string Name { get { return  photo.Name.Replace('s', 'ś').Replace('c', 'ć'); } }

        public string WidthPx { get { return photo.WidthPx; } set { photo.WidthPx = value; } }

        public string HeightPx { get { return photo.HeightPx; } set { photo.HeightPx = value; } }

        public double Longitude { get { return photo.Longitude; } }

        public double Latitude { get { return photo.Latitude; } }
        public string Camera { get { return photo.Camera; } }
        public double[] CameraSettings { get { return photo.CameraSettings; } }
        public DateTime Date { get { return photo.Date; } }

        public override string ToString()
        {
            return Name + " (" + WidthPx + "x" + HeightPx + ")";
        }
    }

}
