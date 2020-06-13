//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Descrambling
{
    public abstract class DescramblerFactory
    {
        public abstract Descrambler GetDescrambler();
    }

    public class BookingDescramblerFactory : DescramblerFactory
    {
        public override Descrambler GetDescrambler()
        {
            DeSwapCodec deSwapCodec = new DeSwapCodec();
            DeCezarCodec deCezarCodec = new DeCezarCodec(-1);
            DeReverseCodec deReverseCodec = new DeReverseCodec();
            DeFrameCodec deFrameCodec = new DeFrameCodec(2);
            deSwapCodec.SetNextDescrambler(deCezarCodec).SetNextDescrambler(deReverseCodec).SetNextDescrambler(deFrameCodec);
            return deSwapCodec;
        }
    }


    public class ShutterStockDescramblerFactory : DescramblerFactory
    {
        public override Descrambler GetDescrambler()
        {
            DeReverseCodec deReverseCodec = new DeReverseCodec();
            DePushCodec dePushCodec = new DePushCodec(-3);
            DeFrameCodec deFrameCodec = new DeFrameCodec(1);
            DeCezarCodec deCezarCodec = new DeCezarCodec(4);
            deReverseCodec.SetNextDescrambler(dePushCodec).SetNextDescrambler(deFrameCodec).SetNextDescrambler(deCezarCodec);
            return deReverseCodec;
        }
    }

    public class TripAdvisorDescramblerFactory : DescramblerFactory
    {
        public override Descrambler GetDescrambler()
        {
            DePushCodec dePushCodec = new DePushCodec(3);
            DeSwapCodec deSwapCodec = new DeSwapCodec();
            DeFrameCodec deFrameCodec = new DeFrameCodec(2);
            DePushCodec dePushCodec2 = new DePushCodec(3);

            dePushCodec.SetNextDescrambler(deSwapCodec).SetNextDescrambler(deFrameCodec).SetNextDescrambler(dePushCodec2);
            return dePushCodec;
        }
    }
}
