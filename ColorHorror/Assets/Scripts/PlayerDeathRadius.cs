using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathRadius : MonoBehaviour
{
    [SerializeField] GameObject rainbowMonster;
    Rigidbody2D rb;

    void Start()
    {
        rb = rainbowMonster.GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GlobalVariables.Instance.isRainbow == false)
        {
            Player.Instance.Playerbody.velocity = new Vector2(0f, 0f);
            Invoke(nameof(StopPlayerMovement), 0.5f);             
        }
    }
    void StopPlayerMovement()
    {
        //2nd movement because monster misses players a lot
        Vector3 playerPos = Player.Instance.Playerbody.transform.position;
        Vector2 monsterForce = (playerPos - rb.transform.position).normalized;
        rb.AddForce(monsterForce * 25, ForceMode2D.Impulse);
        GameObject.FindGameObjectWithTag("Player").SetActive(false);

    }
}
