using LastDitchPlayer.Classes;
using LastDitchPlayer.Playlists;
using NAudio.Wave;
using SoundTouch.Net.NAudioSupport;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.State
{
    public class Playback : PlaybackStates
    {
        private static string lastPlayback = "";

        public override bool isValid()
        {
            throw new NotImplementedException();
        }

        public override void nextSongAuto(Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public override PlaybackStates Play(Track track, WaveOutEvent player, string speed)
        {
            if(lastPlayback != track.FilePath)
            {
                player.Stop();
                lastPlayback = track.FilePath;
            }

            if (player.PlaybackState == PlaybackState.Stopped)
            {
                var audioFile = new AudioFileReader(track.FilePath);

                var output = new SoundTouchWaveProvider(audioFile);


                if (speed == "0.5x")
                {    
                    output.RateChange = -50;
                }
                if (speed == "1.0x")
                {
                    output.RateChange = 0;
                }
                if (speed == "1.5x")
                {
                    output.RateChange = +50;
                }
                if (speed == "2.0x")
                {
                    output.RateChange = +100;
                }
            
                player.Init(output);
            }

            player.Play();
            return new StatePaused();
        }


    }
}

