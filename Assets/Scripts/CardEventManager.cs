using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventManager
{
    public PlayerController player;

    public Stack<Action> behaviorStack;
    public bool inAction;

    public CardEventManager(PlayerController playerObj)
    {
        player = playerObj;
        behaviorStack = new Stack<Action>();
        inAction = false;
    }

    public void FinishedAction(){
        inAction = false;
    }
}
