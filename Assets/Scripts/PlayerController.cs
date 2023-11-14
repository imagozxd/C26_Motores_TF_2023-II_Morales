using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public CharacterController player;
    public Rigidbody rb;

    public float playerSpeed;
    private Vector3 movePlayer;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    void Start()
    {
        player = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //player.Move(new Vector3(horizontalMove, 0, verticalMove)*playerSpeed * Time.deltaTime);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        //leer el valor de entrada 
        Vector2 inputVector = context.ReadValue<Vector2>();

        float directionMovementZ = inputVector.y * playerSpeed;
        float directionMovementX = inputVector.x * playerSpeed;

        camDirection();

        movePlayer = inputVector.x * camRight + inputVector.y * camForward;

        //player.transform.LookAt(player.transform.position+movePlayer);
        if (movePlayer != Vector3.zero)
        {
            player.transform.forward = movePlayer.normalized;
        }

        //aplicando
        rb.velocity = new Vector3(directionMovementX, 0f, directionMovementZ);

        Debug.Log(rb.velocity.magnitude);
    }
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;  

        camForward.y = 0f;
        camRight.y = 0f;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

    }
}
