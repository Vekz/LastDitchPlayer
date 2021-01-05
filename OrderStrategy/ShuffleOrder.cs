using LastDitchPlayer.Classes;
using LastDitchPlayer.Playlists;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.OrderStrategy
{
    public class ShuffleOrder : IOrderStrategy
    {
        Random rand;

        public ShuffleOrder()
        {
            rand = new Random();
        }

        public override Track getNextTrack(Playlist playlist, ref int lastIndex)
        {
            try
            {
                int idx;

                do
                {
                    idx = rand.Next(playlist.getLength());
                } while (lastIndex == rand.Next(playlist.getLength()));

                return playlist[idx];

            }
            catch (ArgumentOutOfRangeException e)
            {
                return null;
            }
        }
    }

}
