using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeckRunner.Positioning
{
    public class TrackList
    {
        public static readonly VerticalTrack leftTrack;
        public static readonly VerticalTrack centerTrack;
        public static readonly VerticalTrack rightTrack;

        // static constructor for three tracks
        static TrackList()
        {
            // fill the information for the track list
            leftTrack = new VerticalTrack();
            centerTrack = new VerticalTrack();
            rightTrack = new VerticalTrack();

            leftTrack.marker = Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 0f, 0f));
            leftTrack.left = null;
            leftTrack.right = centerTrack;

            centerTrack.marker = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f));
            centerTrack.left = leftTrack;
            centerTrack.right = rightTrack;

            rightTrack.marker = Camera.main.ViewportToWorldPoint(new Vector3(0.75f, 0f, 0f));
            rightTrack.left = centerTrack;
            rightTrack.right = null;
        }

    }
}