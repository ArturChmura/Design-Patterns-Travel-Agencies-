//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Interfaces;

//Oyster is a website with reviews of various holiday destinations.
namespace TravelAgencies.DataAccess
{
    class BSTNode
    {
        public string Review { get; set; }
        public string UserName { get; set; }
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }
    }

    class OysterDatabase:IDatabase<IReview>
    {
        public BSTNode Reviews { get; set; }
       

        public IDatabaseIterator<IReview> GetIterator()
        {
            return new OysteDatabaseIterator(this.Reviews);
        }
    }


}
