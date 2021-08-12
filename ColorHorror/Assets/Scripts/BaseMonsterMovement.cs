using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BaseMonsterMovement : IMonsterMovement
{
    private IAstarAI AStar;
    public Monster monster;

    public AIPath Path;

    public BaseMonsterMovement(Monster monster)
    {
        this.monster = monster;
        AStar = monster.GetComponent<IAstarAI>(); // Note: Must get reference to IAstarAI to get velocity, not IAstarAI.velocity itself, so velocity updates every frame
    }

    public void Update()
    {
        if (AStar.velocity.x > 0f) // Case: Enemy moving to the right -> keep local scale same
        {
            monster.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (AStar.velocity.x < 0f) // Case: Enemy moving to the left -> reverse local scale, essentially flipping the character model horizontally
        {
            monster.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // Case: Enemy not moving - don't change local scale/change which way model is facing
    }


    public void Disable()
    {
        monster.gameObject.GetComponent<AIPath>().enabled = false;
    }

    public void Enable()
    {
        monster.gameObject.GetComponent<AIPath>().enabled = true;
    }

    public void Collide(Collision2D collision)
    {

    }
}
