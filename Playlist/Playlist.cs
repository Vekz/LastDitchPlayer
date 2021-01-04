using LastDitchPlayer.Classes;
using LastDitchPlayer.OrderStrategy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.Playlist
{
    public class Playlist : IEnumerable<Track>
    {
        public List<Track> Tracks;

        public IEnumerator<Track> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void setStrategy(IOrderStrategy strategy)
        {
            throw new NotImplementedException();

        }


        public void saveState()
         {
            throw new NotImplementedException();

        }

        internal void loadState(PlaylistSerializer serializer)
        {
            throw new NotImplementedException();

        }

        public void serializePlaylist()
        {
            throw new NotImplementedException();

        }

    }
   
}
