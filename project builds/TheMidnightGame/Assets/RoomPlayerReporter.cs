using UnityEngine;

public class RoomPlayerReporter : MonoBehaviour
{
    public RoomManager roomManager;

    private void Start()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        roomManager = manager.GetComponent<RoomManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Floor")
        {
            Debug.Log("Collided");
            RoomTrackingFloorReporting floorScript = other.GetComponent<RoomTrackingFloorReporting>();
            roomManager.playerRoom = floorScript.Room;
        }
    }
}
