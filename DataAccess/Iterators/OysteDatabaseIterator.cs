//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using TravelAgencies.Interfaces;
using TravelAgencies.Concrete;

//Oyster is a website with reviews of various holiday destinations.
namespace TravelAgencies.DataAccess
{
    class OysteDatabaseIterator:IDatabaseIterator<IReview>
    {
        BSTNode root;
        int info;
        OysteDatabaseIterator iter;
        public bool topMost = true;

        public OysteDatabaseIterator(BSTNode root)
        {
            this.root = root;
            Reset();
        }
       
  
        public void Reset()
        {
            if (root == null) info = 0;
            else
            {
                info = 1;
                iter = new OysteDatabaseIterator(this.root.Left);
            }
        }


        public IReview GetCurrent()
        {
           if(info == 2) return new Review(this.root.Review, this.root.UserName);
           return iter.GetCurrent();
        }

        public bool HasNext()
        {
            if (info == 0)
            {
                return false ;
            }
            if (info == 1)
            {
                bool v = this.iter.HasNext();
                if (v == true)
                {
                    return true;
                }
                info = 2;
                return true;
            }
            if (info == 2)
            {
                info = 3;
                iter = new OysteDatabaseIterator(this.root.Right);
                return iter.HasNext();
            }
            else
            {
                bool v = this.iter.HasNext();
                if (v == true)
                {
                    return true;
                }
                return false;
            }
        }
    }


}
