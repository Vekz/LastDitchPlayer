using LastDitchPlayer.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.OrderStrategy
{
    public class NormalOrder : IOrderStrategy
    {
        private NormalOrder():base()
        {

        }

        public override IOrderStrategy getInstance()
        {
            throw new NotImplementedException();
        }

        public override Track getNextTrack(IEnumerable<Track> trackList)
        {
            throw new NotImplementedException();
        }
    }
}
