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
            MovePlayerRight();
        }

        if (Input.GetMouseButtonDown(0))
        {
            MovePlayerLeft();
        }
    }

    /// <summary>
    /// Move the player left
    /// </summary>
    void MovePlayerLeft()
    {

        if (transform.position == posList.CenterPosition)
            transform.position = posList.LeftPosition;
        else if (transform.position == posList.RightPosition)
            transform.position = posList.CenterPosition;
        else
            print("Unexpected position in MovePlayerLeft");
    }

    ///<summary>
    /// Move the player right
    /// </summary>
    void MovePlayerRight()
    {
        if (transform.position == posList.CenterPosition)
            transform.position = posList.RightPosition;
        else if (transform.position == posList.LeftPosition)
            transform.position = posList.CenterPosition;
        else
            print("Unexpected position in MovePlayerRight");
    }
}
