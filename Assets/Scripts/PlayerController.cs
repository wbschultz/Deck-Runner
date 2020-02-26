using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeckRunner.Positioning;

public class PlayerController : MonoBehaviour
{
    private VerticalTrack currentTrack;

    // Start is called before the first frame update
    void Start()
    {
        currentTrack = TrackList.centerTrack;
    }

    // Update is called once per frame
    void Update()
    {
        // for now, move on a and d, later move cards
        if (Input.GetMouseButtonDown(1))
        {
            MovePlayer(currentTrack.right);
        }

        if (Input.GetMouseButtonDown(0))
        {
            MovePlayer(currentTrack.left);
        }
    }

    /// <summary>
    /// move the player left
    /// </summary>
    /// <param name="target">VerticalTrack object to jump to</param>
    void MovePlayer(VerticalTrack target)
    {
        if (target != null)
        {
            transform.position = new Vector3(target.marker.x, transform.position.y, transform.position.z);
            currentTrack = target;
        }
    }
}
