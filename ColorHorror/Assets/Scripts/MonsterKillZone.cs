using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKillZone : MonoBehaviour
{

    [SerializeField] GameObject rainbowMonster;
    GameObject player;
    Vector3 originalLocation;
    Rigidbody2D rb;
    LevelLoader levelLoader;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = rainbowMonster.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && GlobalVariables.Instance.isRainbow == false)
        {
            RunOverPlayer();
        }

    }

    void RunOverPlayer()
    {
        originalLocation = rb.transform.position;

        Vector2 force = (player.transform.position - rb.transform.position);
        rb.AddForce(force, ForceMode2D.Impulse);

        player.GetComponent<Rigidbody2D>().simulated = false; // turn off player movement
        player.GetComponent<Collider2D>().enabled = false; // makes player runover-able
       
        Invoke("DisablePlayer", 1f);    
        Invoke("GoBackToLocation", 2f);
        LoadDeathScene();
    }

    void DisablePlayer()
    {
        player.gameObject.SetActive(false);
        rb.velocity = new Vector2 (0f, 0f);
    }

    void LoadDeathScene(){
        levelLoader.LoadDeathScene();
    }
    void GoBackToLocation()
    {
        Vector2 force = (originalLocation - rb.transform.position);
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (GlobalVariables.Instance.isRainbow)
        {
            rb.isKinematic = true; // makes sure the player can't push the monster when rainbow
        }
    }
}
