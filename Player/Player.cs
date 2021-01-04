using LastDitchPlayer.Classes;
using LastDitchPlayer.OrderStrategy;
using LastDitchPlayer.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.Player
{
   public class Player
    {
        public List<Track> currentPlaylist;
        public List<IOrderStrategy> strategies;
        public PlaybackState currentState;
    }
}
