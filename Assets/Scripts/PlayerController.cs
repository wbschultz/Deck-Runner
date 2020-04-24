using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeckRunner.Positioning;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float leftRightDuration = 0.5f;

    public delegate void onBehaviorComplete();
    public event onBehaviorComplete onComplete;

    private TrackList posList;
    private Vector3 target;
    private Vector3 current;

    // Start is called before the first frame update
    private void Start()
    {
        posList = new TrackList(transform.position);
        current = posList.CenterPosition;
        target = posList.CenterPosition;
    }

    /// <summary>
    /// Move the player left or right
    /// </summary>
    public void MovePlayer(bool left)
    {
        if(left)
            target = posList.leftTarget(current);
        else
            target = posList.rightTarget(current);
            
        Tween tweener = transform.DOMove(target, leftRightDuration);
        tweener.onComplete += () => {
            current = target;
            onComplete();
        };
    }

    /// <summary>
    /// Fire beam to destroy enemy ships
    /// <summary>
    public void Beam(){
        
    }
}
