using LastDitchPlayer.Classes;
using LastDitchPlayer.Playlists;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.OrderStrategy
{
   public abstract class IOrderStrategy
    {
        public abstract Track getNextTrack(Playlist playlist, ref int lastIndex); 
        public abstract Track getPrevTrack(Playlist playlist, ref int lastIndex); 
    }
}
