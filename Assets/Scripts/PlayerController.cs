using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Link to camera
    public FollowPlayer cameraScript;

    // Movement tuning (editable in Inspector)
    public float speed = 5.0f;
    public float turnSpeed = 100f;
    // Input System actions
    public InputAction MoveAction;
    // Current input value (x = left/right, y= forward/back), kept private for internal use.
    public Vector2 moveInput;

    // Rear View
    public InputAction rearViewAction;

    // Movement States
    private bool isMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // MoveAction starts receiving input.
        MoveAction.Enable();
        rearViewAction.Enable();
    }

    

    // Update is called once per frame
    void Update()
    {
        // Read 2D vector from MoveAction
        moveInput = MoveAction.ReadValue<Vector2>();

        // set isMoving boolean
        isMoving = Mathf.Abs(moveInput.y) > 0.01f;

        // Move forward/backward along z using y component
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        // Rotate around local Y using the x component.
        if (isMoving)
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveInput.x * Mathf.Sign(moveInput.y));

        // Handle Rear Camera
        bool codeIsPressingKey = rearViewAction.ReadValue<float>() > 0.5f;
        cameraScript.lookingBehind = codeIsPressingKey;
    }
}
