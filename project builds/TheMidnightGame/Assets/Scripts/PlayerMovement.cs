using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{

    CharacterController controller;
    Vector3 moveDirection;
    Vector3 movementVector;
    Transform cameraTransform;


    [SerializeField] float moveSpeed = 1;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void OnMove(InputValue input)
    {
        //updates x and z values of moveDirection vector according to player input
        Vector2 inputVector = input.Get<Vector2>();
        moveDirection = new Vector3(inputVector.x, 0, inputVector.y).normalized;

    }

    void Update()
    {
        //adjusts move direction to be relative to the current facing direction (so w always goes forward)
        //this causes the player to move slower if they are looking up or down, though. (this is fixed below)
        movementVector = cameraTransform.forward * moveDirection.z + cameraTransform.right * moveDirection.x;

        //removes any vertical influence on the vector so the player moves at full speed
        movementVector.y = 0;
        movementVector.Normalize();

        //no deltatime because simplemove is framerate independent! :)
        controller.SimpleMove(movementVector * moveSpeed);
    }
}
