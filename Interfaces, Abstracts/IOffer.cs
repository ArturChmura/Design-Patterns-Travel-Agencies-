//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
namespace TravelAgencies.Interfaces
{
    interface IOffer
    {
        bool Timed { get; }
        int ExpireTime { get; set; }
        string Present();

    }
}