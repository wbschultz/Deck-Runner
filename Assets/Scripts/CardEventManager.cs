using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventManager : SingletonBase<CardEventManager>
{
    private PlayerController player;

    private Stack<Action> behaviorStack = new Stack<Action>();
    private bool inAction;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        player.onComplete += FinishedAction;
    }

    // Update is called once per frame
    private void Update()
    {
        // for now, move on a and d, later move cards
        if (Input.GetMouseButtonDown(1))
        {
            behaviorStack.Push(() => player.MovePlayer(false));
        }

        if (Input.GetMouseButtonDown(0))
        {
            behaviorStack.Push(() => player.MovePlayer(true));
        }
    }

    private void FixedUpdate()
    {
        if (!inAction && behaviorStack.Count > 0){
            inAction = true;
            Action nextAction = behaviorStack.Pop();
            nextAction();
        }
    }

    private void FinishedAction(){
        inAction = false;
    }
}
