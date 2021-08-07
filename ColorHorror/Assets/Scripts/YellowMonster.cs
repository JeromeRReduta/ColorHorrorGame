using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMonster : Monster
{

    public TempPlayer player; 

    /** Cooldown of teleport, in seconds */
    public static int tpCooldown = 1;

    /** Counter used to keep track of current teleport cooldown, in frames */
    private static int countdown = YellowMonster.tpCooldown * 60;

    private int currentCountDown = countdown;

    /**
    Attempts to teleport in front of player every x seconds, otherwise chases towards player
    */
    public override void Update()
    {
    }

    public void FixedUpdate() {
        Debug.Log("TELEPORT: In 1 second, player will be @: " + player.FuturePoint);
        if (--currentCountDown == 0) {
            currentCountDown = countdown;
            this.transform.position = player.FuturePoint;
        }

    }


    public override void PlayWalkSound()
    {
        base.Audio.Play("YellowMonWalk");
    }

    public override void StopWalkSound()
    {
        base.Audio.Stop("YellowMonWalk");
    }

    public override void PlayHitSound()
    {
        base.Audio.Play("YellowMonHit");
    }

}
