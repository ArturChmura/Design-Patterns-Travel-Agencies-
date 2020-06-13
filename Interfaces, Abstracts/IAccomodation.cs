//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

namespace TravelAgencies.Interfaces
{
    interface IAccomodation
    {
        string Name { get; }
        string Price { get; set; }
        string Rating { get; set; }

        string ToString();
    }
}
