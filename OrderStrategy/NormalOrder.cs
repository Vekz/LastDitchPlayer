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
                position += 1;
                return playlist[position];
            }
            catch (ArgumentOutOfRangeException e)
            {
                return null;
            }
        }

        public override Track getPrevTrack(Playlist playlist, ref int lastIndex)
        {
            try
            {
                lastIndex -= 1;
                return playlist[lastIndex];
            }
            catch (ArgumentOutOfRangeException e)
            {
                return null;
            }
        }
    }
}
