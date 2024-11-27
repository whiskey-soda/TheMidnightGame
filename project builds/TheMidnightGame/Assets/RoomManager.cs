using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> rooms;
    public GameObject playerRoom;
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Room")
            {
                rooms.Add(child.gameObject);
            }
        }
    }
}
