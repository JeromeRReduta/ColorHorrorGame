using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

/**
Class whose sole responsibility is to represent the red monster.

Red monster behavior:
1) Move towards player indefinitely
2) Every 2 seconds, charge towards player location in a straight line until it hits something
*/ 
public class RedMonster : Monster // TODO: 1) Make changing levels disable the old monsters' aggro, complete w/ stopping sounds
    // 2) Make red monster charge not track the player (or at least, so closely)
{
    public override void Start()
    {
        base.Start();
        base.CurrentColor = Color.red;
    }


    public void PlayChargeSound()
    {
        base.PlaySound("RedMonCharge");
    }

    public void StopChargeSound()
    {
        base.StopSound("RedMonCharge");
    }

    public override void PlayWalkSound()
    {
        base.PlaySound("RedMonWalk");
    }

    public override void StopWalkSound()
    {
        base.StopSound("RedMonWalk");
    }

    public override void PlayHitSound()
    {
        base.PlaySound("RedMonHit");
    }

}