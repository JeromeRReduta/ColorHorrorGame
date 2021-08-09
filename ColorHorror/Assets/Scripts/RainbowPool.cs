using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowPool : MonoBehaviour
{
    [SerializeField] GameObject lights, text;
    [SerializeField] GameObject emptyPool, fullPool, animationStarter;
    Collider2D radius, playerCol;
    bool animationIsReady, textHasShown;
    [SerializeField] Animator bucketAnimRed, bucketAnimYellow, bucketAnimBlue;

    void Start()
    {
        radius = animationStarter.GetComponent<Collider2D>();
        playerCol = lights.GetComponentInParent<Collider2D>();
    }
    void Update()
    {
        if (GlobalVariables.Instance.gotAllBuckets == true)
        {
            if (GlobalVariables.Instance.isRainbow == false)
            {
                animationIsReady = true;
            }
            else
            {
                animationIsReady = false;
            }
        }
        else
        {
            animationIsReady = false;
            emptyPool.gameObject.SetActive(true);
            fullPool.gameObject.SetActive(false);
            lights.gameObject.SetActive(false);
            textHasShown = false;
            GlobalVariables.Instance.isRainbow = false;
        }

        if (animationIsReady == true && playerCol.IsTouching(radius))
        {
            if (textHasShown == false)
            {
                text.SetActive(true);
                textHasShown = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                text.SetActive(false);
                animationIsReady = false;
                Invoke("AddRed", 0f);
                Invoke("AddYellow", 1f);
                Invoke("AddBlue", 2f);
                Invoke("makeRainbow", 3.2f);
            }
        }
        else
        {
            text.SetActive(false);
            textHasShown = false;
        }
    }

    void AddRed()
    {
        bucketAnimRed.Play("AddingPaint");
    }

    void AddYellow()
    {
        bucketAnimYellow.Play("AddingPaint");
    }

    void AddBlue()
    {
        bucketAnimBlue.Play("AddingPaint");
    }

    void makeRainbow()
    {
        emptyPool.gameObject.SetActive(false);
        fullPool.gameObject.SetActive(true);
        lights.gameObject.SetActive(true);
        GlobalVariables.Instance.isRainbow = true;
    }
}
