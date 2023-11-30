using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 velocity; // Vector de velocidad privado

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        velocity = new Vector3(movementInput.x * speed,0f, movementInput.y * speed);        
    }
    public void OnPressJ(InputAction.CallbackContext context)
    {
        if (context.performed)
        {            
            Debug.Log("Tecla presionada es J ");
            // aqui la logica para lanzar la animacion
        }
    }

    public void OnPressK(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Tecla presionada es K ");
            // aqui la logica para lanzar la animacion
        }
    }
}

