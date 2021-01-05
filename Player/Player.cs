using LastDitchPlayer.Classes;
using LastDitchPlayer.OrderStrategy;
using LastDitchPlayer.Playlists;
using LastDitchPlayer.State;
using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace LastDitchPlayer.Players
{
   public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Playlist playlist { get; set; }

        public List<IOrderStrategy> strategies;
        private int strategyIdx = 0;

        public PlaybackStates currentState { get; set; }

        public WaveOutEvent audioPlayer;

        public ICommand PlayCommand { get; }
        public ICommand ChangeStrategyCommand { get; }
        public ICommand OpenSongCommand { get; }
        public ICommand OpenPlaylistCommand { get; }
        public ICommand SavePlaylistCommand { get; }


        public Player()
        {
            //Setting up default output device
            audioPlayer = new WaveOutEvent();

            //Setting up default playback state
            currentState = new Playbackx1();

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
        }

        void Play()
        {
            foreach(Track track in playlist)
            {
                currentState.Play(track, audioPlayer); //Will this wait for the end of the song i dont know?
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
        }

        void OpenPlaylist()
        {
            throw new NotImplementedException(); //TODO: LOADING PLAYLIST FROM FILE
        }

        void SavePlaylist()
        {
            playlist.serializePlaylist(); //or saveState() i'm not sure? //TODO: SAVING PLAYLIST TO FILE
        }

    }
}
