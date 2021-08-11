using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRadius : MonoBehaviour
{
    [SerializeField] CameraShake cameraShake;
    public GameObject player;
    [SerializeField] GameObject monsterRadius, monsterDangerZone;


    void Update()
    {
        Collider2D monsterRadCol = monsterRadius.GetComponent<Collider2D>();
        Collider2D monsterDangerCol = monsterDangerZone.GetComponent<Collider2D>();
        Collider2D playerCol = player.GetComponent<Collider2D>();
        Camera cam = this.gameObject.GetComponentInChildren<Camera>();

        if (playerCol.IsTouching(monsterRadCol))
        {
            cam.enabled = true;
        }
        else
        {
            cam.enabled = false;
        }

        if (playerCol.IsTouching(monsterDangerCol) && GlobalVariables.Instance.isRainbow == false)
        {
            StartCoroutine(cameraShake.Shake(1f, .25f));
        }
    }
}
