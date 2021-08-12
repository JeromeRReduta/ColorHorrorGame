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
public abstract class Monster : Mob // TODO: rename to "Monster" once done, then delete old "Monster" (low-prio - after cleaning up workspace)
{

    // Movement and special will be added as components and run separately

    public delegate void SetAggroAction(bool aggroOn);
    public event SetAggroAction OnChangingAggro;

    public IMonsterMovement movement;
    public IMonsterSpecial special;


    public enum TypeOfMovement {Base};
    public TypeOfMovement movementChoice;

    public enum TypeOfSpecial {NoSpecial, Charge, Teleport};
    public TypeOfSpecial specialChoice;






    /** Start */
    public override void Start()
    {
        base.Start();
        PlayWalkSound();
        SetMovement();
        SetSpecial();
    }

    public void SetMovement()
    {
        if (movementChoice == TypeOfMovement.Base)
        {
            movement = new BaseMonsterMovement(this);
        }
    }

    public void SetSpecial()
    {
        if (specialChoice == TypeOfSpecial.NoSpecial)
        {
            special = new NoSpecial(this);
        }
        else if (specialChoice == TypeOfSpecial.Charge) // TODO: implement this
        {
            special = new Charge(this);
        }
        else if (specialChoice == TypeOfSpecial.Teleport)
        {
            special = new Teleport(this);
        }
    }

    public override void Update()
    {
        movement.Update();
        special.Update();

    }
    
    /**
    Collision logic. On collision with anything, the monster stops. On collision with player, attempts to deal damage to player.
    @param collision Collision data
    */
    public override void OnCollisionEnter2D(Collision2D collision)
    {

        movement.Collide(collision);
        special.Collide(collision);
        
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
            movement.Disable();
            special.Disable();
        }
        else
        {
            Debug.Log("ENABLING AGGRO");
            EnableAggro();
            movement.Enable();
            special.Enable();
        }
    }

    public virtual void DisableAggro()
    {
        if (OnChangingAggro != null)
        {
            OnChangingAggro(false);
        }
    }
    public virtual void EnableAggro()
    {
        if (OnChangingAggro != null)
        {
            OnChangingAggro(true);
        }
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
