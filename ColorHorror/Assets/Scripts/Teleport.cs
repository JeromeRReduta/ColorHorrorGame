using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
A monster's special pattern
*/
public class Teleport : IMonsterSpecial
{

    private Monster monster;

       /** Counter used to keep track of current teleport cooldown, in frames */
    private static int tpCooldown = 1200;
    private int currentCountDown;

    /**
    Attempts to teleport in front of player every x seconds, otherwise chases towards player
    */

    public Vector3 FuturePoint {get; private set;}
    float rayCastLength;

    // Movement: Base; Special: Teleport
    public Teleport(Monster monster)
    {
        this.monster = monster;
        currentCountDown = tpCooldown;
    }


    public void Update() {
        //Debug.Log("CD: " + currentCountDown);
        //Debug.Log("Player movement: - x: " + Player.Instance.movement.x + " y: " + Player.Instance.movement.y);
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
                    LayerMask.GetMask("Walls" , "Room", "Monster")).collider == null;
        bool canTPBehindPlayer = Physics2D.Raycast(playerPos, PlayerOrientation * -1, rayCastLength, 
                    LayerMask.GetMask("Walls" , "Room", "Monster")).collider == null;

        if (canTPInFrontOfPlayer)
        {
            monster.transform.position = new Vector3(playerPos.x + (PlayerOrientation.x * rayCastLength), playerPos.y + (PlayerOrientation.y * rayCastLength), playerPos.z);
            monster.PlaySound("YellowMonTP"); 
        }
        else if (canTPBehindPlayer)
        {
            monster.transform.position = new Vector3(playerPos.x - (PlayerOrientation.x * rayCastLength), playerPos.y - (PlayerOrientation.y * rayCastLength), playerPos.z);
            monster.PlaySound("YellowMonTP");
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
    public void SetTP(bool isOn)
    {
        Debug.Log("SETTING TP COOLDOWN TO : " + (isOn ? "1200" : "-1"));
        currentCountDown = isOn ? tpCooldown : -1;
    }

    public void Disable()
    {
        currentCountDown = -1;
    }

    public void Enable()
    {
        if (currentCountDown <= 0)
        {
            currentCountDown = tpCooldown;
        }
    }

    public void Collide(Collision2D collision)
    {
        
    }



}
