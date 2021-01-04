using LastDitchPlayer.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.OrderStrategy
{
   public abstract class IOrderStrategy
    {
        private IOrderStrategy instance;

        protected IOrderStrategy()
        {

        }

        public abstract IOrderStrategy getInstance();
        public abstract Track getNextTrack(IEnumerable<Track> trackList); 
    }
}
