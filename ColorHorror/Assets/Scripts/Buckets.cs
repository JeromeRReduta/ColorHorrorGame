using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckets : MonoBehaviour
{
    [SerializeField] GameObject blueBucket, redBucket, yellowBucket;

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.Instance.gotBlueBucket == true)
        {
            blueBucket.gameObject.SetActive(true);
        }
        else
        {
            blueBucket.gameObject.SetActive(false);
        }
        if (GlobalVariables.Instance.gotRedBucket == true)
        {
            redBucket.gameObject.SetActive(true);
        }
        else
        {
            redBucket.gameObject.SetActive(false);
        }
        if (GlobalVariables.Instance.gotYellowBucket == true)
        {
            yellowBucket.gameObject.SetActive(true);
        }
        else
        {
            yellowBucket.gameObject.SetActive(false);
        }
    }
}
