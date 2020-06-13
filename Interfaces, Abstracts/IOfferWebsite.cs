//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
namespace TravelAgencies.Interfaces
{
    interface IOfferWebsite
    {
        void Present();
        void AddAgency(IAdvertisingAgency agency);

    }
}