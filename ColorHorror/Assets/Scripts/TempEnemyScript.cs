using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TempEnemyScript : MonoBehaviour // TODO: Merge this into monster
{
    public AIPath aiPath;
    Animator animator;
    Rigidbody2D rb;

    IAstarAI AStar;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        AStar = GetComponent<IAstarAI>(); // Note: Must get reference to IAstarAI to get velocity, not IAstarAI.velocity itself, so velocity updates every frame
    }
    void Update()
    {
        //bool isMoving = vel.x != 0f || vel.y != 0f;
        //animator.SetBool("Running", isMoving); // Note:Animator is set to go from entry -> running, so it will always play running animation - bool unnecessary


        if (AStar.velocity.x > 0f) // Case: Enemy moving to the right -> keep local scale same
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (AStar.velocity.x < 0f) // Case: Enemy moving to the left -> reverse local scale, essentially flipping the character model horizontally
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // Case: Enemy not moving - don't change local scale/change which way model is facing
    }
}
