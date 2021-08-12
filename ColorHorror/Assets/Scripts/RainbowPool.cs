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
        if (GlobalVariables.Instance.gotAllBuckets)
        {
            animationIsReady = !GlobalVariables.Instance.isRainbow;
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

        if (animationIsReady && playerCol.IsTouching(radius))
        {
            if (!textHasShown)
            {
                text.SetActive(true);
                textHasShown = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                text.SetActive(false);
                animationIsReady = false;

                StartCoroutine( fillPool() );
            }
        }
        else
        {
            text.SetActive(false);
            textHasShown = false;
        }
    }

    private IEnumerator fillPool()
    {
        bucketAnimRed.Play("AddingPaint");
        yield return new WaitForSeconds(1);
        
        bucketAnimYellow.Play("AddingPaint");
        yield return new WaitForSeconds(1);

        bucketAnimBlue.Play("AddingPaint");
        yield return new WaitForSeconds(1);

        emptyPool.gameObject.SetActive(false);
        fullPool.gameObject.SetActive(true);
        lights.gameObject.SetActive(true);
        GlobalVariables.Instance.isRainbow = true;
    }
}
