using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectInRoom : MonoBehaviour
{
    GameObject thisObject;
    Collider2D col;

    void Start()
    {
        thisObject = this.gameObject;
        col = thisObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        if (col.IsTouchingLayers(LayerMask.GetMask("Room")))
        {
            if (col.IsTouching(RoomScriptNew.Instance.currentlyActiveRoom.gameObject.GetComponentInChildren<Collider2D>()))
            {
                SpriteRenderer[] spriteRenderers = thisObject.gameObject.GetComponentsInChildren<SpriteRenderer>();
                for (int j = 0; j < spriteRenderers.Length; j++)
                {
                    spriteRenderers[j].enabled = true;
                }
              
            }
            else
            {
                SpriteRenderer[] spriteRenderers = thisObject.gameObject.GetComponentsInChildren<SpriteRenderer>();
                for (int j = 0; j < spriteRenderers.Length; j++)
                {
                    spriteRenderers[j].enabled = false;
                }
            }
        }
    }
}
