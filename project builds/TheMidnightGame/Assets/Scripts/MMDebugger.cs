using UnityEngine;

public class MMDebugger : MonoBehaviour
{

    MMMovement pathfindingScript;

    public Vector3 pathfindingDestination;
    public Vector3 teleportDestination;
    

    void Start()
    {
        pathfindingScript = FindAnyObjectByType<MMMovement>();
    }

    [ContextMenu("Set Pathfinding Destination")]
    void SetPathfindingDestination()
    {
        pathfindingScript.SetPathingTargetTo(pathfindingDestination);
    }

    [ContextMenu("Teleport")]
    void Teleport()
    {
        pathfindingScript.TeleportTo(teleportDestination);
    }

}
