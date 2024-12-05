using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CloseDoors : MonoBehaviour
{
    List<Door> doorsInRange = new List<Door>();

    private void OnTriggerEnter(Collider other)
    {
        // adds door to list of doors in range if it is not already in there
        Door doorScript = other.GetComponent<Door>();
        if (doorScript != null && !doorsInRange.Contains(doorScript))
        {
            doorsInRange.Add(doorScript);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // removes door from list of doors in range
        Door doorScript = other.GetComponent<Door>();
        if (doorScript != null && doorsInRange.Contains(doorScript))
        {
            doorsInRange.Remove(doorScript);
        }
    }

    public void CloseDoor(Door door)
    {
        if (door.doorState != Door.DoorState.closed
            && door.doorState != Door.DoorState.closing)
        {
            door.ProcessInteraction();
        }
    }

    void CloseNearestDoor()
    {
        if (!doorsInRange.Any()) { return; }

        CloseDoor( FetchClosestDoorInRange());
    }

    private Door FetchClosestDoorInRange()
    {
        if (!doorsInRange.Any()) { return null; }

        Door closestDoor = null;
        float closestDoorDistance = 0;

        foreach (Door door in doorsInRange)
        {
            float distanceToDoor = Vector3.Distance(door.transform.position, transform.position);
            if (distanceToDoor < closestDoorDistance
                || closestDoor == null)
            {
                closestDoor = door;
                closestDoorDistance = distanceToDoor;
            }
        }

        return closestDoor;
    }
}
