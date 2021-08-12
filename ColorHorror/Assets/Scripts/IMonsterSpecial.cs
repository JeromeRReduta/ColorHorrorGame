using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
A monster's special pattern
*/
public interface IMonsterSpecial
{

    void Update();


    void Disable();
    void Enable();

    void Collide(Collision2D collision);
}