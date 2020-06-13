//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using TravelAgencies.Interfaces;
namespace TravelAgencies.Concrete
{
    public class Review : IReview
    {
        public string Text { get; }

        public string Author { get; }
        public Review(string text,string author)
        {
            Text = text;
            Author = author;
        }
        public Review()
        {
            Text = "";
            Author = "";
        }
    }
}