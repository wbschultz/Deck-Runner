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

    CardEventManager eventManager;

    // Start is called before the first frame update
    private void Start()
    {
        eventManager = new CardEventManager(GetComponent<PlayerController>());

        posList = new TrackList(transform.position);
        current = posList.CenterPosition;
        target = posList.CenterPosition;

        onComplete += eventManager.FinishedAction;
    }

    // Update is called once per frame
    private void Update()
    {
        // for now, move on a and d, later move cards
        if (Input.GetMouseButtonDown(1))
        {
            eventManager.behaviorStack.Push(() => MovePlayer(false));
        }

        if (Input.GetMouseButtonDown(0))
        {
            eventManager.behaviorStack.Push(() => MovePlayer(true));
        }
    }

    private void FixedUpdate()
    {
        if (!eventManager.inAction && eventManager.behaviorStack.Count > 0)
        {
            eventManager.inAction = true;
            Action nextAction = eventManager.behaviorStack.Pop();
            nextAction();
        }
    }

    /// <summary>
    /// Move the player left or right
    /// </summary>
    public void MovePlayer(bool left)
    {
        if(left && current != posList.LeftPosition)
            target = posList.leftTarget(current);
        else if (!left && current != posList.RightPosition)
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
