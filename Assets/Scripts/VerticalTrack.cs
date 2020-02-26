using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeckRunner.Positioning 
{
    public class VerticalTrack
    {
        public Vector3 marker;  // marker for position of track
        public VerticalTrack left;      // track on this track's left
        public VerticalTrack right;     // track on this track's right
    }
}
