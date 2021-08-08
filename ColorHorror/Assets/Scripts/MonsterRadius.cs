using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRadius : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject monsterRadius;
    [SerializeField] GameObject dangerRadius;
    CameraShake cameraShake;

    void Start()
    {
        cameraShake = gameObject.GetComponentInChildren<CameraShake>();
    }

    void Update()
    {
        Collider2D monsterRadCol = monsterRadius.GetComponent<Collider2D>();
        Collider2D dangerRadCol = dangerRadius.GetComponent<Collider2D>();
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

        if (playerCol.IsTouching(dangerRadCol) && GlobalVariables.Instance.isRainbow == false)
        {
            StartCoroutine(cameraShake.Shake(1f, .2f));
        }
    }
}
