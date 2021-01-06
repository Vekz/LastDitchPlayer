using LastDitchPlayer.Classes;
using LastDitchPlayer.OrderStrategy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LastDitchPlayer.Playlists
{
    public class Playlist : IEnumerator<Track>
    {
        public ObservableCollection<Track> Tracks { get; set; }
        public IOrderStrategy currentStrategy;
        public string Name;

        //Custom enumerator vars
        public Track Current { get; private set; }
        object IEnumerator.Current => this.Current;
        private int position = 0;

        public Playlist()
        {
            Tracks = new ObservableCollection<Track>();
        }

        public Track this[int index]
        {
            get { return Tracks[index]; }
            set { Tracks.Insert(index, value); }
        }

        //Implement iterator interface
        public bool MoveNext()
        {
            Track tmp;
            tmp = currentStrategy.getNextTrack(this, ref position);
            if(tmp != null) 
            {
                Current = tmp;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = 0;
        }

        public void Dispose(){}

        //Custom collection methods
        public int getLength()
        {
            return Tracks.Count;
        }

        public void addTrack(Track track)
        {
            Tracks.Add(track);
        }

        //Strategy pattern
        public void setStrategy(IOrderStrategy strategy)
        {
            currentStrategy = strategy;
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

            IEnumerable<Track> obsCollection = (IEnumerable<Track>)Tracks;
            var list = new List<Track>(obsCollection);
            PlaylistSerializer state = new PlaylistSerializer(list, this.Name);
            state.Serialize(Name);

        }

    }
   
}
