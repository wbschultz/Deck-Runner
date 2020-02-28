using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeckRunner.Positioning
{
    public class TrackList
    {

        private Vector3 leftPosition;
        private Vector3 centerPosition;
        private Vector3 rightPosition;
        private Vector3 referencePosition;

        public Vector3 LeftPosition { get { return leftPosition; } }
        public Vector3 CenterPosition { get { return centerPosition; } }
        public Vector3 RightPosition { get { return rightPosition; } }

        ///<summary> 
        ///Create a new set of 3 markers on the x axis using refPos as a reference for y and z
        ///</summary>
        public TrackList(Vector3 refPos){
            referencePosition = refPos;
            InstantiatePositions();
        }

        ///<summary> 
        ///Create a new set of 3 markers on the x axis using (0, 0, 0) as a reference for y and z
        ///</summary>
        public TrackList(){
            referencePosition = new Vector3(0, 0, 0);
            InstantiatePositions();
        }

        ///<summary> 
        ///Instantiate x position markers at the center of the screen, 25% from the left, and 25% from the right
        ///</summary>
        private void InstantiatePositions()
        {
            leftPosition = new Vector3(
                Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 0f, 0f)).x,
                referencePosition.y,
                referencePosition.z
            );

            centerPosition = new Vector3(
                Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f)).x,
                referencePosition.y,
                referencePosition.z
            );

            rightPosition = new Vector3(
                Camera.main.ViewportToWorldPoint(new Vector3(0.75f, 0f, 0f)).x,
                referencePosition.y,
                referencePosition.z
            );
        }

    }
}