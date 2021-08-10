using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

/**
Base code for all monsters

Every monster has the following properties:
1) Collider2D
2) Rigidbody2D

Every monster has the following behavior:
1) Moves towards players - handled by a* algorithm
2) Whenever it hits anything, stops. Whenever it hits the player, attempts to damage player.
*/
public abstract class NewMonster : Mob // TODO: rename to "Monster" once done, then delete old "Monster" (low-prio - after cleaning up workspace)
{

    /** Start */
    public override void Start()
    {
        base.Start();
        PlayWalkSound();
    }
    
    /**
    Collision logic. On collision with anything, the monster stops. On collision with player, attempts to deal damage to player.
    @param collision Collision data
    */
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("EH this is fine");
        Rb.velocity = new Vector2(0f, 0f);
        Debug.Log("Name is: " + collision.gameObject.name);
        Debug.Log("string.equals(collision.gameObject.name, Player) is " + string.Equals(collision.gameObject.name, "Player"));

        if (string.Equals(collision.gameObject.name, "Player")) { // If monster collides with player, deal damage to player
            Debug.Log("Gottem - dealing 1 damage to player");
            PlayHitSound();
        }
        
    }

    public void TryDisableAggro(Color playerColor) // TODO: Change name to "ChangeAggro"
    {

        Debug.Log("current color: " + base.CurrentColor + " player color: " + playerColor);
        Debug.Log("Equal to each other? " + (base.CurrentColor == playerColor));
        if (base.CurrentColor == playerColor)
        {
            Debug.Log("DISABLING AGGRO");
            DisableAggro();
        }
        else
        {
            Debug.Log("ENABLING AGGRO");
            EnableAggro();
        }
    }

    public virtual void DisableAggro()
    {
        GetComponent<TempEnemyScript>().aiPath.enabled = false;
    }
    public virtual void EnableAggro()
    {
        GetComponent<TempEnemyScript>().aiPath.enabled = true;
    }

    public override void OnEnable()
    {
        Player.OnColorChange += TryDisableAggro;
    }

    public override void OnDisable()
    {
        Player.OnColorChange -= TryDisableAggro;
    }
}
