using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

// bubba;

/**
Base code for all monsters

Every monster has the following properties:
1) Collider2D
2) Rigidbody2D

Every monster has the following behavior:
1) Moves towards players - handled by a* algorithm
2) Whenever it hits anything, stops. Whenever it hits the player, attempts to damage player.
*/
public abstract class Monster : MonoBehaviour
{
    // Note: Public typeName X {get; private set;}
    // means we can call X's value from any other class (implied public get), but can only set its value in this class (private set)

    /** This monster's collider */
    public Collider2D Col {get; private set;}

    /** This monster's rigid body */
    public Rigidbody2D Rb {get; private set;}

    /** This monter's AudioManager */
    public AudioManager Audio;

    [SerializeField] public Color color;

    /** Start */
    public virtual void Start()
    {
        Col = GetComponent<Collider2D>();
        Rb = GetComponent<Rigidbody2D>();

        PlayWalkSound();
    }

    /** Update func */
    public abstract void Update();
    
    /**
    Collision logic. On collision with anything, the monster stops. On collision with player, attempts to deal damage to player.
    @param collision Collision data
    */
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("EH this is fine");
        Rb.velocity = new Vector2(0f, 0f);
        Debug.Log("GOOD");
        Debug.Log(collision);
        Debug.Log("Name is: " + collision.gameObject.name);
        Debug.Log("string.equals(collision.gameObject.name, Player) is " + string.Equals(collision.gameObject.name, "Player"));

        if (string.Equals(collision.gameObject.name, "Player")) { // If monster collides with player, deal damage to player
            Debug.Log("Gottem - dealing 1 damage to player");
            PlayHitSound();
        }
        
    }

    public abstract void PlayWalkSound();

    public abstract void StopWalkSound();

    public abstract void PlayHitSound();

    public void TryDisableAggro(Color playerColor)
    {
        Debug.Log("MONSTER COLOR == PLAYER COLOR? " + (color == playerColor));
        Debug.Log(color == playerColor ? "DISABLING" : "ENABLING" + "AGGRO");
        if (color == playerColor)
        {
            DisableAggro();
        }
        else
        {
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

    void OnEnable()
    {
        Player.OnColorChange += TryDisableAggro;
    }

    void OnDisable()
    {
        Player.OnColorChange -= TryDisableAggro;
    }
}
