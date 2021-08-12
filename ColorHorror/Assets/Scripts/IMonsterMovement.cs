using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
A monster's movement pattern
*/
public interface IMonsterMovement
{
    void Update();

    void Disable();
    void Enable();

    void Collide(Collision2D collision);


}