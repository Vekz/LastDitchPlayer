using LastDitchPlayer.Classes;
using LastDitchPlayer.OrderStrategy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LastDitchPlayer.Playlists
{
    public class Playlist : IEnumerable<Track>
    {
        public ObservableCollection<Track> Tracks { get; set; }
        public IOrderStrategy currentStrategy;

        private int lastIndex = 0;

        public Playlist()
        {
            Tracks = new ObservableCollection<Track>();
        }

        public Track this[int index]
        {
            get { return Tracks[index]; }
            set { Tracks.Insert(index, value); }
        }

        public IEnumerator<Track> GetEnumerator()
        {
            Track tmp;

            tmp = currentStrategy.getNextTrack(this, ref lastIndex);

            if (tmp != null) { yield return tmp; }
            else { yield break; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void setStrategy(IOrderStrategy strategy)
        {
            currentStrategy = strategy;
        }

        public int getLength()
        {
            return Tracks.Count;
        }

        public void addTrack(Track track)
        {
            Tracks.Add(track);
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
