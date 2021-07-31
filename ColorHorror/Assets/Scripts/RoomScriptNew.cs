using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScriptNew : MonoBehaviour
{
    public static RoomScriptNew Instance;
    GameObject[] allRooms;
    public GameObject currentlyActiveRoom;


    // Start is called before the first frame update
    void Start()
    {
        allRooms = GameObject.FindGameObjectsWithTag("SeparateRoom");
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        bool isCollidingWithRoom = false;
       

        for (int i = 0; i < allRooms.Length; i++) {
            if (Player.Instance.Playerbody.IsTouching(allRooms[i].GetComponentInChildren<Collider2D>()))
            {   
                SpriteRenderer[] spriteRenderers = allRooms[i].gameObject.GetComponentsInChildren<SpriteRenderer>();
                for (int j = 0; j < spriteRenderers.Length; j++)
                {
                    spriteRenderers[j].enabled = true;
                }
                allRooms[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
                isCollidingWithRoom = true;

                currentlyActiveRoom = allRooms[i];
            
            }
            // else 
            // {
            //     SpriteRenderer[] spriteRenderers = allRooms[i].gameObject.GetComponentsInChildren<SpriteRenderer>();
            //     for (int j = 0; j < spriteRenderers.Length; j++)
            //     {
            //         spriteRenderers[j].enabled = false;
            //     }
            //     allRooms[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
            // }

        }

        for (int k = 0; k < allRooms.Length; k++)
        {
            if (allRooms[k] != currentlyActiveRoom)
            {
                SpriteRenderer[] spriteRenderers = allRooms[k].gameObject.GetComponentsInChildren<SpriteRenderer>();
                for (int j = 0; j < spriteRenderers.Length; j++)
                {
                    spriteRenderers[j].enabled = false;
                }
                allRooms[k].gameObject.transform.GetChild(0).gameObject.SetActive(false); // turns off the light in the room
            }
        }

        if (isCollidingWithRoom == false)
        {
            SpriteRenderer[] spriteRenderers = currentlyActiveRoom.gameObject.GetComponentsInChildren<SpriteRenderer>();
            for (int j = 0; j < spriteRenderers.Length; j++)
            {
                spriteRenderers[j].enabled = true;
            }
            currentlyActiveRoom.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
