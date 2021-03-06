using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMonsterNew : NewMonster
{

    /** Counter used to keep track of current teleport cooldown, in frames */
    private static int tpCooldown = 600;
    private int currentCountDown;

    /**
    Attempts to teleport in front of player every x seconds, otherwise chases towards player
    */

    public Vector3 FuturePoint {get; private set;}
    float rayCastLength;

    public override void Start()
    {
        base.Start();
        base.CurrentColor = Color.yellow;
        currentCountDown = tpCooldown;
    }


    public override void Update() {
        //Debug.Log("CD: " + currentCountDown);
        Debug.Log("Player movement: - x: " + Player.Instance.movement.x + " y: " + Player.Instance.movement.y);
        if (currentCountDown > 0)
        {
            currentCountDown--;
        }
        else if (currentCountDown == 0)
        {
            TryTeleport();
            currentCountDown = tpCooldown;
        }
    }

    public void TryTeleport()
    {
        // Case: Player not moving - do nothing
        if (Player.Instance.movement.x == 0 && Player.Instance.movement.y == 0) return;

        Vector3 PlayerOrientation = getPlayerOrientation();
        Vector3 playerPos = Player.Instance.gameObject.transform.position;
        float rayCastLength = Player.Instance.CharacterSpeed * 0.7f;
        bool canTPInFrontOfPlayer = Physics2D.Raycast(playerPos, PlayerOrientation, rayCastLength, 
                    LayerMask.GetMask("Walls" , "Monster")).collider == null;
        bool canTPBehindPlayer = Physics2D.Raycast(playerPos, PlayerOrientation * -1, rayCastLength, 
                    LayerMask.GetMask("Walls" , "Monster")).collider == null;

        if (canTPInFrontOfPlayer)
        {
            this.transform.position = new Vector3(playerPos.x + (PlayerOrientation.x * rayCastLength), playerPos.y + (PlayerOrientation.y * rayCastLength), playerPos.z);
            PlayTeleportSound(); 
        }
        else if (canTPBehindPlayer)
        {
            this.transform.position = new Vector3(playerPos.x - (PlayerOrientation.x * rayCastLength), playerPos.y - (PlayerOrientation.y * rayCastLength), playerPos.z);
            PlayTeleportSound();
        }
    }

    public Vector3 getPlayerOrientation()
    {
        Vector3 PlayerOrientation = Vector3.zero;

        if (Player.Instance.movement.x > 0) // Case: player moving right
        {
            PlayerOrientation += Vector3.right;
        }
        else if (Player.Instance.movement.x < 0) // Case: player moving left
        {
            PlayerOrientation += Vector3.left;
        }
        // Case: Player not moving horizontally - don't edit PlayerOrientation

        if (Player.Instance.movement.y > 0) { // Case: Player moving up
            PlayerOrientation += Vector3.up;
        }
        else if (Player.Instance.movement.y < 0) { // Case: Player moving down
            PlayerOrientation += Vector3.down;
        }
        // Case: Player not moving vertically - don't edit PlayerOrientation

        return PlayerOrientation;

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
