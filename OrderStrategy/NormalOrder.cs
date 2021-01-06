using LastDitchPlayer.Classes;
using LastDitchPlayer.Playlists;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.OrderStrategy
{
    public class NormalOrder : IOrderStrategy
    {
        public override Track getNextTrack(Playlist playlist, ref int position)
        {
            try
            {
                return playlist[position++];
            }
            catch (ArgumentOutOfRangeException e)
            {
                return null;
            }
        }
    }
}
