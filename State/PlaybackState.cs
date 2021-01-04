using LastDitchPlayer.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.State
{
    public abstract class PlaybackState
    {
        float runtime;

        public abstract bool isValid();

        public abstract void Play(Track track);

    }
}
