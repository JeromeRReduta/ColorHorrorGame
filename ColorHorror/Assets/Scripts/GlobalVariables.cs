using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables Instance;
    public bool gotRedBucket, gotBlueBucket, gotYellowBucket;
    [HideInInspector] public bool gotAllBuckets;
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

}
