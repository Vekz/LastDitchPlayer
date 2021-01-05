using LastDitchPlayer.Classes;
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

        public override void Play(Track track)
        {
            throw new NotImplementedException();
        }
    }
}
