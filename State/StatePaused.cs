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

        public override void Play(Track track, WaveOutEvent player)
        {
            throw new NotImplementedException();
        }
    }
}
