using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMonsterNew : MonoBehaviour
{

    /** Cooldown of teleport, in seconds */
    public static int tpCooldown = 5;

    /** Counter used to keep track of current teleport cooldown, in frames */
    private static int countdown = YellowMonster.tpCooldown * 60;

    private int currentCountDown = countdown;

    /**
    Attempts to teleport in front of player every x seconds, otherwise chases towards player
    */

    public Vector3 FuturePoint {get; private set;}
    float CharacterSpeed;
    public void FixedUpdate() {
    
        if (--currentCountDown <= 0) {
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
                    currentCountDown = countdown;

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
                        currentCountDown = countdown;
                    }
                }
                // else
                // {
                //     float distance = hit.distance > 0 ? hit.distance : CharacterSpeed;
                //     FuturePoint = hit.distance > 0 ? (Vector3) hit.point : this.transform.position + CharacterSpeed * lineDir;
                //     Debug.Log("Distance: " + hit.distance);
                //     Debug.DrawLine(this.transform.position, FuturePoint, Color.red, 2, false);
                //     Debug.Log("Starting position: " + this.transform.position);
                //     Debug.Log("Final position: " + FuturePoint);

                //     Debug.Log("TELEPORT: In 1 second, player will be @: " + FuturePoint);
                //     this.transform.position = FuturePoint;

                // }

                // if raycast hits wall, then does not teleport and countdown is reset
                
            }
        }

    }
}
