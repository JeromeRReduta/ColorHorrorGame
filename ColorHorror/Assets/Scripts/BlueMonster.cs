using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
Class whose sole responsibility is to represent the blue monster and its behavior.

Note that it is identical in functionality to the white monster, except that it is blue.
*/
public class BlueMonster : NewMonster
{
    public override void Start()
    {
        base.Start();
        base.CurrentColor = Color.blue;
    }

    public override void PlayWalkSound()
    {
        base.PlaySound("BlueMonWalk");
    }

    public override void StopWalkSound()
    {
        base.StopSound("BlueMonWalk");
    }

    public override void PlayHitSound()
    {
        base.PlaySound("BlueMonHit");
    }
}
