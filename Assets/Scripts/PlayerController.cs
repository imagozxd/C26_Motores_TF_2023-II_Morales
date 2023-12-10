using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 velocity; // Vector de velocidad privado
    public Animator animator;

    public int damage;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // Verificamos si animator no es null antes de intentar acceder a él
        if (animator != null)
        {
            // Verificamos si hay movimiento para activar/desactivar la animación
            if (Keyboard.current.sKey.isPressed)
            {
                // Activamos la animación "Walking" si hay movimiento
                animator.SetBool("IsWalking", true);
                Debug.Log("Se está reproduciendo la animación");
            }
            else
            {
                // Desactivamos la animación si no hay movimiento
                animator.SetBool("IsWalking", false);
            }
        }
        Debug.Log("Animator: " + animator);
        if (animator != null)
        {
            Debug.Log("no hay animator ingresado");
        }


        rb.velocity = velocity;
    }
    private void FixedUpdate()
    {
        //rb.velocity = velocity;

       
    }

    public void OnPressD(InputAction.CallbackContext context)
    {
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        velocity = new Vector3(movementInput.x * speed,0f, movementInput.y * speed);
        Debug.Log("Movimiento detectado: " + velocity +"ZZ" + gameObject.name);

        if (movementInput.x > 0)
        {
            //  gameObject.transform.Rotate(new Vector3(0, 500, 0) * Time.deltaTime);
        }
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

