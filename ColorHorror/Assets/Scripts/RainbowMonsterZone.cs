using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowMonsterZone : MonoBehaviour
{

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // According to https://forum.unity.com/threads/layermask-nametolayer-performance.402620/ benchmarking, nameToLayer() is actually pretty efficient (as efficient as dictionary)
        int playerLayer = LayerMask.NameToLayer("Player");
        //Debug.Log("Player layer is: " + playerLayer);
        //Debug.Log("Player color is: " + player.Color);
        
        /* TODO: Add color functionality to Player, not just TempPlayer - in fact, move everything to Player
        if (player.Color == "Rainbow") {
            Physics2D.IgnoreLayerCollision(playerLayer, playerLayer);
        }

        else {
            Physics2D.IgnoreLayerCollision(playerLayer, playerLayer, false);
        }
        */

        
        
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Colliding with: " + collision.gameObject.name);

        // Note: Maybe have to make this check inside player instead? (have player itself figure out whether it's touched rainbow monster zone w/o being rainbow)
        if (string.Equals(collision.gameObject.name, "Player")) // TODO: Also make this check for rainbow color
        {
            Debug.Log("Killing player");

        }

    }
}
