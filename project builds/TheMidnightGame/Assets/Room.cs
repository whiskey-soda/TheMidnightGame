using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> floors;
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Floor")
            {
                RoomTrackingFloorReporting floorScript = child.GetComponent<RoomTrackingFloorReporting>();
                floorScript.Room = gameObject;
                floors.Add(child.gameObject);
            }
        }
    }
}
