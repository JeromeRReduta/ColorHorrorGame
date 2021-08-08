using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowPool : MonoBehaviour
{
    [SerializeField] GameObject lights;
    [SerializeField] GameObject emptyPool, fullPool, animationStarter;
    Collider2D radius, playerCol;
    bool animationIsReady = false;

    void Start()
    {
        radius = animationStarter.GetComponent<Collider2D>();
        playerCol = lights.GetComponentInParent<Collider2D>();
    }
    void Update()
    {
        if (GlobalVariables.Instance.gotAllBuckets == true)
        {
            animationIsReady = true;
        }
        else
        {
            animationIsReady = false;
            emptyPool.gameObject.SetActive(true);
            fullPool.gameObject.SetActive(false);
            lights.gameObject.SetActive(false);
        }

        if (animationIsReady == true && playerCol.IsTouching(radius))
        {
            
            emptyPool.gameObject.SetActive(false);
            fullPool.gameObject.SetActive(true);
            lights.gameObject.SetActive(true);
            GlobalVariables.Instance.isRainbow = true;
        }
    }
}
