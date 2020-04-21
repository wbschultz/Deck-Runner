using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeckRunner.Positioning;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float leftRightDuration = 0.5f;

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

        Vector3 target;

        if (transform.position == posList.CenterPosition)
        {
            target = posList.LeftPosition;
        }
        else if (transform.position == posList.RightPosition)
        {
            target = posList.CenterPosition;
        }
        else
        {
            print("Unexpected position in MovePlayerRight");
            return;
        }

        transform.DOMove(target, leftRightDuration);
    }

    ///<summary>
    /// Move the player right
    /// </summary>
    void MovePlayerRight()
    {
        Vector3 target;

        if (transform.position == posList.CenterPosition)
        {
            target = posList.RightPosition;
        }
        else if (transform.position == posList.LeftPosition)
        {
            target = posList.CenterPosition;
        }
        else
        {
            print("Unexpected position in MovePlayerRight");
            return;
        }

        transform.DOMove(target, leftRightDuration);
    }
}
