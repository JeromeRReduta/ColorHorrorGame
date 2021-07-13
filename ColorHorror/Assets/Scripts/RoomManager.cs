using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;
    public bool inHallway = true;
    public bool inMiddleRoom, inUpperRoom;

    [SerializeField] private GameObject hallway, middleRoom, upperRoom;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void ChangeActiveRoom()
    {
        if (inUpperRoom == true)
        {
            hallway.SetActive(false);
            middleRoom.SetActive(false);
            upperRoom.SetActive(true);
        }
        else if (inMiddleRoom == true) 
        {
            hallway.SetActive(false);
            middleRoom.SetActive(true);
            upperRoom.SetActive(false);
        }
        else if (inHallway == true)
        {
            hallway.SetActive(true);
            middleRoom.SetActive(false);
            upperRoom.SetActive(false);

        }
    }
}
