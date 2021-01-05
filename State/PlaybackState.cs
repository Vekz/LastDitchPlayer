using LastDitchPlayer.Classes;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.State
{
    public abstract class PlaybackStates
    {
        float runtime;

        public abstract bool isValid();

        public abstract void Play(Track track, WaveOutEvent player);

    }
}
