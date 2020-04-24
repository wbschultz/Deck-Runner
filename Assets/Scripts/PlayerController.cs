using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeckRunner.Positioning;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float leftRightDuration = 0.5f;

    private Stack<Action> behaviorStack = new Stack<Action>();
    private bool inAction;

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

    private void FixedUpdate()
    {
        if (!inAction && behaviorStack.Count > 0){
            inAction = true;
            Action nextAction = behaviorStack.Pop();
            nextAction();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // for now, move on a and d, later move cards
        if (Input.GetMouseButtonDown(1))
        {
            behaviorStack.Push(() => MovePlayer(false));
        }

        if (Input.GetMouseButtonDown(0))
        {
            behaviorStack.Push(() => MovePlayer(true));
        }
    }

    /// <summary>
    /// Move the player left or right
    /// </summary>
    void MovePlayer(bool left)
    {
        if(left)
            target = posList.leftTarget(current);
        else
            target = posList.rightTarget(current);
        Tween tweener = transform.DOMove(target, leftRightDuration);
        tweener.onComplete += () => {
            current = target;
            inAction = false;
        };
    }
}
