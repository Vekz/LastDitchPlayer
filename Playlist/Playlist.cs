using LastDitchPlayer.Classes;
using LastDitchPlayer.OrderStrategy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.Playlists
{
    public class Playlist : IEnumerable<Track>
    {
        public List<Track> Tracks;
        public IOrderStrategy currentStrategy;

        private int lastIndex = 0;

        public Track this[int index]
        {
            get { return Tracks[index]; }
            set { Tracks.Insert(index, value); }
        }

        public IEnumerator<Track> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Track tmp;

            tmp = currentStrategy.getNextTrack(this, ref lastIndex);

            if (tmp != null) { yield return tmp; }
            else { yield break; }
        }

        public void setStrategy(IOrderStrategy strategy)
        {
            currentStrategy = strategy;
        }

        public int getLength()
        {
            return Tracks.Count;
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
