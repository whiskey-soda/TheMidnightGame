using UnityEngine;
using UnityEngine.AI;

public class MMMovement : MonoBehaviour
{

    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Sets the Midnight Man's NavMeshAgent's destination to a given Vector3
    /// </summary>
    /// <param name="target"></param>
    public void SetPathingTargetTo(Vector3 target)
    {
        agent.SetDestination(target);
    }

    /// <summary>
    /// Reset's the Midnight Man's NevMeshAgent's path, stopping it's movement
    /// </summary>
    public void CancelPath()
    {
        agent.ResetPath();
    }

    /// <summary>
    /// Sets the Midnight Man's position to a given Vector3
    /// </summary>
    /// <param name="destination"></param>
    public void TeleportTo(Vector3 destination)
    {
        transform.position = destination;
    }

}
