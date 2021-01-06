using LastDitchPlayer.Classes;
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

        public override PlaybackStates Play(Track track, WaveOutEvent player, string speed)
        {
            player.Pause();
            return new Playback();
        }
    }
}
