using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeckRunner.Positioning;

public class PlayerController : MonoBehaviour
{
    private TrackList posList;

    // Start is called before the first frame update
    private void Start()
    {
        posList = new TrackList(transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        // for now, move on a and d, later move cards
        if (Input.GetMouseButtonDown(1))
        {
            MovePlayer(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            MovePlayer(true);
        }
    }

    /// <summary>
    /// Move the player left or right
    /// </summary>
    /// <param name="left">if left is true move left, else move right</param>
    void MovePlayer(bool left)
    {
        if (left)
        {
            if (transform.position == posList.CenterPosition)
                transform.position = posList.LeftPosition;
            else if (transform.position == posList.RightPosition)
                transform.position = posList.CenterPosition;
            else
                print("Unexpected position in MovePlayer");
        } else 
        {
            if (transform.position == posList.CenterPosition)
                transform.position = posList.RightPosition;
            else if (transform.position == posList.LeftPosition)
                transform.position = posList.CenterPosition;
            else
                print("Unexpected position in MovePlayer");
        }
    }
}
