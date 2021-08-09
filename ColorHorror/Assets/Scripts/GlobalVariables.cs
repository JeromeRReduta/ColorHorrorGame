using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    GameObject redBucket, yellowBucket, blueBucket;
    public static GlobalVariables Instance;
    public bool gotRedBucket, gotBlueBucket, gotYellowBucket;
    [HideInInspector] public bool gotAllBuckets, isRainbow;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if (gotRedBucket == true && gotBlueBucket == true && gotYellowBucket == true)
        {
            gotAllBuckets = true;
        }
        else
        {
            gotAllBuckets = false;
        }
    }
    public void ClickRedButton()
    {
        // redBucket = GameObject.FindGameObjectWithTag("RedBucket");
        gotRedBucket = true;
        // redBucket.gameObject.SetActive(false);

    }

    public void ClickYellowButton()
    {
        // yellowBucket = GameObject.FindGameObjectWithTag("YellowBucket");
        gotYellowBucket = true;
        // yellowBucket.gameObject.SetActive(false);
    }

    public void ClickBlueButton()
    {
        // blueBucket = GameObject.FindGameObjectWithTag("BlueBucket");
        gotBlueBucket = true;
        // blueBucket.gameObject.SetActive(false);
    }

}
