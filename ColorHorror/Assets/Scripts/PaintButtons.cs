using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintButtons : MonoBehaviour
{
     GameObject redBucket, yellowBucket, blueBucket;
    public void ClickRedButton()
    {
        redBucket = GameObject.FindGameObjectWithTag("RedBucket");
        GlobalVariables.Instance.gotRedBucket = true;
        redBucket.gameObject.SetActive(false);

    }

    public void ClickYellowButton()
    {
        yellowBucket = GameObject.FindGameObjectWithTag("YellowBucket");
        GlobalVariables.Instance.gotYellowBucket = true;
        yellowBucket.gameObject.SetActive(false);
    }

    public void ClickBlueButton()
    {
        blueBucket = GameObject.FindGameObjectWithTag("BlueBucket");
        GlobalVariables.Instance.gotBlueBucket = true;
        blueBucket.gameObject.SetActive(false);
    }
}
