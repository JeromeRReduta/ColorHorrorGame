using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

/**
Base code for all monsters
*/
public class Monster : MonoBehaviour
{
    // Note: Public typeName X {get; private set;}
    // means we can call X's value from any other class (implied public get), but can only set its value in this class (private set)

    public Collider2D Col {get; private set;}
    public Rigidbody2D Rb {get; private set;}

    public virtual void Start()
    {
        Col = GetComponent<Collider2D>();
        Rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Update()
    {
        // Path handles the movement logic, so don't have to do anything here
    }

    // Need OnCollisionEnter2D for 2d objects, not OnCollisionEnter
    void OnCollisionEnter2D(Collision2D collision)
    {
        Rb.velocity = new Vector2(0f, 0f);
        Debug.Log(collision);
        Debug.Log("Name is: " + collision.gameObject.name);
        Debug.Log("string.equals(collision.gameObject.name, Player) is " + string.Equals(collision.gameObject.name, "Player"));

        if (string.Equals(collision.gameObject.name, "Player")) { // If monster collides with player, deal damage to player
            Debug.Log("Gottem - dealing 1 damage to player");
        }
        
    }

}
