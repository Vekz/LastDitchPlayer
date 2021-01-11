using LastDitchPlayer.Classes;
using LastDitchPlayer.OrderStrategy;
using LastDitchPlayer.Playlists;
using LastDitchPlayer.State;
using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace LastDitchPlayer.Players
{
   public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Playlist secretPlaylist;
        public Playlist playlist { 
            get
            {
                return secretPlaylist;
            }
            set
            {
                secretPlaylist = value;
                OnPropertyChanged("playlist");
            }
        }

        public List<IOrderStrategy> strategies;
        private int strategyIdx = 0;

        public PlaybackStates currentState { get; set; }

        private ObservableCollection<string> states;
        public ObservableCollection<string> States 
        {
            get { return this.states;  }
            set
            {
                this.states = value;
                OnPropertyChanged("States");
            }
        }
        private string sstate;
        public string Sstate
        {
            get { return sstate; }
            set
            {
                this.sstate = value;
                OnPropertyChanged("Sstate");
            }
        }

        private Track sitem;
        public Track Sitem
        {
            get { return sitem; }
            set
            {
                this.sitem = value;
                playlist.selectTrack(sitem);
                OnPropertyChanged("Sitem");
            }
        }

        public WaveOutEvent audioPlayer;

        public ICommand PlayCommand { get; }
        public ICommand ChangeStrategyCommand { get; }
        public ICommand OpenSongCommand { get; }
        public ICommand OpenPlaylistCommand { get; }
        public ICommand SavePlaylistCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand RedoCommand { get; }
        public ICommand NextAudioCommand { get; }
        public ICommand PrevAudioCommand { get; }


        public Player()
        {
            //Setting up default output device
            audioPlayer = new WaveOutEvent();

            //Populate states combobox
            States = new ObservableCollection<string>() { "0.5x", "1.0x", "1.5x", "2.0x" };

            //Setting up default playback state
            currentState = new Playback();
            Sstate = states[1];

            //Setting up flyweight pattern
            strategies = new List<IOrderStrategy>();
            strategies.Add(new NormalOrder());
            strategies.Add(new ShuffleOrder());

            //Setting up default playlist
            playlist = new Playlist();
            playlist.setStrategy(strategies[strategyIdx]);
            strategyIdx++;

            //Setting up buttons delegates
            PlayCommand = new DelegateCommand(Play);
            OpenSongCommand = new DelegateCommand(OpenSong);
            OpenPlaylistCommand = new DelegateCommand(OpenPlaylist);
            SavePlaylistCommand = new DelegateCommand(SavePlaylist);
            ChangeStrategyCommand = new DelegateCommand(ChangeStrategy);
            UndoCommand = new DelegateCommand(Undo);
            RedoCommand = new DelegateCommand(Redo);
            NextAudioCommand = new DelegateCommand(NextAudio);
            PrevAudioCommand = new DelegateCommand(PrevAudio);
        }

        void Play()
        {
            Track track = playlist.Current;
            if(track != null)
            {

                currentState = currentState.Play(track, audioPlayer, Sstate);

                if (currentState.GetType().FullName != "LastDitchPlayer.State.StatePaused") 
                {
                    //if (!playlist.MoveNext())
                    //    playlist.Reset();
                }
            }
        }

        void ChangeStrategy()
        {
            switch (strategyIdx)
            {
                case 0:
                    playlist.setStrategy(strategies[strategyIdx]);
                    strategyIdx = 1;
                    break;
                case 1:
                    playlist.setStrategy(strategies[strategyIdx]);
                    strategyIdx = 0;
                    break;
            }
        }
        
        void OpenSong()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Supported Files (*.wav;*.mp3)|*.wav;*.mp3|All Files (*.*)|*.*";
            bool? result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                String fName = openFileDialog.FileName;
                AudioFileReader audioFile = new AudioFileReader(fName);
                playlist.addTrack(new Track(fName.Remove(fName.LastIndexOf(".")), fName, audioFile.TotalTime.TotalMinutes));
                audioFile.Dispose();
            }
            playlist.MoveNext();
        }

        #region Getting and saving playlists
        /// <summary>
        /// Opens file dialog which lets user to load playlist from xml file.
        /// </summary>
        void OpenPlaylist()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Playlist in XML format|*.xml";
            bool? result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                String fName = openFileDialog.FileName;
                playlist = PlaylistSerializer.Deserialize(fName);
                playlist.setStrategy(strategies[strategyIdx]);
            }
        }

        /// <summary>
        /// Opens file dialog which lets user to save playlist to xml file.
        /// </summary>
        void SavePlaylist()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML file|*.xml";
            saveFileDialog1.Title = "Save a playlist file";
            saveFileDialog1.ShowDialog();
            playlist.Name = saveFileDialog1.FileName == String.Empty ? UtilClass.RandomAlphaNumericString(10) : saveFileDialog1.FileName;
            playlist.serializePlaylist(); 
        }
        #endregion

        #region Memento
        void Undo()
        {
            throw new NotImplementedException();
        }
        void Redo()
        {
            throw new NotImplementedException();

        }

        #endregion

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Change/Reset current audio
        
        private void NextAudio()
        {
            audioPlayer.Stop();
            if (!playlist.MoveNext() && playlist.Current == null)
            {
                playlist.Reset();
            }
           // OnPropertyChanged("playlist");
            Play();
            Play();
        }

        private void PrevAudio()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
