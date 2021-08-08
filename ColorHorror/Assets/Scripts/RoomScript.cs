using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    [SerializeField] GameObject hallwayOnly, upperRoomOnly, midRoomOnly;
    Collider2D roomCollider;

    void Start()
    {
        roomCollider = this.gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {

        if (this.gameObject == hallwayOnly && Player.Instance.Playerbody.IsTouching(roomCollider))
        {
            RoomManager.Instance.inHallway = true;
            RoomManager.Instance.inMiddleRoom = false;
            RoomManager.Instance.inUpperRoom = false;
        }
        else if (this.gameObject == midRoomOnly && Player.Instance.Playerbody.IsTouching(roomCollider)) //if doesn't work then change to if
        {
            RoomManager.Instance.inHallway = false;
            RoomManager.Instance.inMiddleRoom = true;
            RoomManager.Instance.inUpperRoom = false;
        }
        else if (this.gameObject == upperRoomOnly && Player.Instance.Playerbody.IsTouching(roomCollider))
        {
            RoomManager.Instance.inHallway = false;
            RoomManager.Instance.inMiddleRoom = false;
            RoomManager.Instance.inUpperRoom = true;
        }
        RoomManager.Instance.ChangeActiveRoom();

    }
}
