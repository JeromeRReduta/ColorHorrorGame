using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMonsterNew : NewMonster
{

    /** Counter used to keep track of current teleport cooldown, in frames */
    private static int tpCooldown = 120;
    private int currentCountDown;

    /**
    Attempts to teleport in front of player every x seconds, otherwise chases towards player
    */

    public Vector3 FuturePoint {get; private set;}
    float CharacterSpeed;

    public override void Start()
    {
        base.Start();
        base.CurrentColor = Color.yellow;
        currentCountDown = tpCooldown;
    }

    public override void Update()
    {

    }

    public override void DisableAggro()
    {
        base.DisableAggro();
        currentCountDown = -1;
    }

    public override void EnableAggro()
    {
        base.EnableAggro();
        currentCountDown = tpCooldown;
    }
    
    public void FixedUpdate() {

        if (currentCountDown > 0)
        {
            currentCountDown--;
        }
        else if (currentCountDown == 0)
        {
            Vector3 lineDir = Vector3.zero;

            if (Player.Instance.movement.x > 0)
            {
                lineDir += Vector3.right;
            }
            else if (Player.Instance.movement.x < 0)
            {
                lineDir += Vector3.left;
            }

            if (Player.Instance.movement.y > 0) {
                lineDir += Vector3.up;
            }
            else if (Player.Instance.movement.y < 0) {
                lineDir += Vector3.down;
            }

            lineDir = lineDir.normalized;

            if (lineDir.x != 0 || lineDir.y != 0)
            {
                Debug.Log(lineDir.x);
                Vector3 playerPos = Player.Instance.gameObject.transform.position;

                CharacterSpeed = Player.Instance.CharacterSpeed;

                RaycastHit2D hit = Physics2D.Raycast(playerPos, lineDir, CharacterSpeed, 
                    LayerMask.GetMask("Walls" , "Monster"));

                FuturePoint = new Vector3 (playerPos.x + (lineDir.x * CharacterSpeed), playerPos.y + (lineDir.y * CharacterSpeed), playerPos.z); 
                Debug.DrawLine(playerPos, FuturePoint, Color.red, 2, false);

                if (!hit)
                {
                    this.transform.position = FuturePoint;
                    currentCountDown = tpCooldown;
                }
                else
                {
                    RaycastHit2D hitBack = Physics2D.Raycast(playerPos, -lineDir, CharacterSpeed, 
                    LayerMask.GetMask("Walls" , "Monster"));

                    FuturePoint = new Vector3 (playerPos.x - (lineDir.x * 4), playerPos.y - (lineDir.y * 4), playerPos.z); 
                    Debug.DrawLine(playerPos, FuturePoint, Color.red, 2, false);
                    if (!hitBack)
                    {
                        this.transform.position = FuturePoint;
                        
                    }


                    currentCountDown = tpCooldown;
                }

                PlayTeleportSound();
            }
        }
    }

    public override void PlayWalkSound()
    {
        base.PlaySound("YellowMonWalk");
    }

    public override void StopWalkSound()
    {
        base.StopSound("YellowMonWalk");
    }

    public override void PlayHitSound()
    {
        base.PlaySound("YellowMonHit");
    }

    public void PlayTeleportSound()
    {
        base.PlaySound("YellowMonTP");
    }
}
