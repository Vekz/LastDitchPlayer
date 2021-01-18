using LastDitchPlayer.Classes;
using LastDitchPlayer.Playlists;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.State
{
    public class StatePaused : PlaybackStates
    {
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
            player.Pause();
            return new Playback();
        }

    }
}
