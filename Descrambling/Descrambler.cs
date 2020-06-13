//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Descrambling
{
    public abstract class Descrambler
    {
        Descrambler nextDescrambler;
        public Descrambler SetNextDescrambler(Descrambler nextDescrambler)
        {
            return this.nextDescrambler = nextDescrambler;
        }
        public virtual string Handle(string number)
        {
            if (nextDescrambler != null)
            {
                number = nextDescrambler.Handle(number);
            }
            return number;

        }

    }

    public class DeFrameCodec : Descrambler
    {
        int n;
        public DeFrameCodec(int n)
        {
            this.n = n;
        }

        public override string Handle(string number)
        {
            if (n < 0) throw new ArgumentException("DeFrameCodec cant handle negative numbers");
            number = number.Substring(n, number.Length - 2 * n);
            return base.Handle(number);
        }


    }
    public class DeReverseCodec : Descrambler
    {
        public override string Handle(string number)
        {
            char[] charArray = number.ToCharArray();
            Array.Reverse(charArray);
            number = new string(charArray);
            return base.Handle(number);
        }
    }

    public class DePushCodec : Descrambler
    {
        int n;
        public DePushCodec(int n)
        {
            this.n = n;
        }
        public override string Handle(string number)
        {
            int push = n;
            while (push < 0)
            {
                push += number.Length;
            }
            push = push % number.Length;
            number = number.Substring(push, number.Length - push) + number.Substring(0, push);
            return base.Handle(number);
        }
    }

    public class DeCezarCodec : Descrambler
    {
        int n;
        public DeCezarCodec(int n)
        {
            this.n = n;
        }
        public override string Handle(string number)
        {
            int shift = n;
            while (shift < 0) shift += 10;
            shift = shift % 10;
            char[] charArray = number.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] -= '0';
                if (charArray[i] < (char)shift)
                {
                    charArray[i] += (char)10;
                }
                charArray[i] -= (char)shift;
                charArray[i] += '0';
            }
            number = new string(charArray);
            return base.Handle(number);
        }
    }

    public class DeSwapCodec : Descrambler
    {
        public override string Handle(string number)
        {
            char[] charArray = number.ToCharArray();
            for (int i = 1; i < charArray.Length; i += 2)
            {
                char h = charArray[i];
                charArray[i] = charArray[i - 1];
                charArray[i - 1] = h;
            }
            number = new string(charArray);
            return base.Handle(number);
        }

    }
}
