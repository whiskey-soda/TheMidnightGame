using UnityEngine;

public class Door : InteractableProp
{

    [SerializeField] float maxOpenRotation = -115;
    [SerializeField] float rotateSpeed = 150;

    Quaternion closedAngle;
    Quaternion openAngle;


    public enum DoorState { open, closed, opening, closing }

    public DoorState doorState = DoorState.closed;

    protected override void Awake()
    {
        base.Awake();

        closedAngle = transform.parent.rotation;
        openAngle = Quaternion.Euler(transform.parent.rotation.eulerAngles + new Vector3(0, maxOpenRotation, 0));
    }

    private void Update()
    {

        if (doorState == DoorState.opening)
        {
            transform.parent.rotation = Quaternion.RotateTowards(transform.parent.rotation, openAngle, rotateSpeed * Time.deltaTime);

            if (transform.parent.rotation == openAngle)
            {
                doorState = DoorState.open;
            }
        }

        if (doorState == DoorState.closing)
        {
            transform.parent.rotation = Quaternion.RotateTowards(transform.parent.rotation, closedAngle, rotateSpeed * Time.deltaTime);

            if(transform.parent.rotation == closedAngle)
            {
                doorState = DoorState.closed;
            }
        }
    }

    public override void ProcessInteraction()
    {
        switch (doorState)
        {
            case DoorState.open:
                doorState = DoorState.closing;
                break;

            case DoorState.closed:
                doorState = DoorState.opening;
                break;

            case DoorState.opening:
                doorState = DoorState.closing;
                break;

            case DoorState.closing:
                doorState = DoorState.opening;
                break;
        }

    }
}
