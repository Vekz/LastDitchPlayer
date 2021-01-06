﻿using LastDitchPlayer.Classes;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastDitchPlayer.State
{
    public class Playbackx1 : PlaybackStates
    {
        public override bool isValid()
        {
            throw new NotImplementedException();
        }

        public override PlaybackStates Play(Track track, WaveOutEvent player)
        {
            var audioFile = new AudioFileReader(track.FilePath);
            if(player.PlaybackState == PlaybackState.Stopped) 
            { 
                player.Init(audioFile);
            }
            player.Play();
            return new StatePaused();
        }
    }
}
