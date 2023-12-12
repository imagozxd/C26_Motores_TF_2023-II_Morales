using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody rb;
    private Vector3 velocity;
    public float velocidadRotacion = 180f;

    private float rotacionY;

    public int damage;

    //control vida del jugador
    public int vidaMaxima = 100;
    public int vidaActual;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vidaActual = vidaMaxima;

    }
    private void Update()
    { 
    }
    private void FixedUpdate() //NECESITO EXPLICACION XD
    {
        // Aplica la rotación al objeto en el eje Y dentro de FixedUpdate
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotacionY * Time.fixedDeltaTime, 0));

        // Aplica la rotación al vector de dirección del movimiento utilizando transform.forward
        Vector3 rotatedDirection = Quaternion.Euler(0, rotacionY * Time.fixedDeltaTime, 0) * transform.forward;
        rb.velocity = rotatedDirection * velocity.z;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        float directionMovement = context.ReadValue<float>() * velocidad;
        velocity = new Vector3(0, 0, directionMovement);
        Debug.Log("valor :" + context.ReadValue<float>());
    }

    public void Direction(InputAction.CallbackContext context)
    {
        float directionRotate = context.ReadValue<float>();
        Debug.Log("valor directionRotate :" + context.ReadValue<float>());

        // Calcula la cantidad de rotación en el eje Y
        rotacionY = directionRotate * velocidadRotacion;

    }
    public void OnPressD(InputAction.CallbackContext context)
    {

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

    public void TalarArbol()
    {
        int bajarVida = 10; //cambiar por el metodo
        ReducirVida(bajarVida);
    }
    public void Comer()
    {
        int subirVida = 10;
        AumentarVida(subirVida);
    }
    void ReducirVida(int cantidad)
    {
        vidaActual -= cantidad;

        // Asegúrate de que la vida no sea menor que 0
        vidaActual = Mathf.Max(vidaActual, 0);

        Debug.Log("Vida actual: " + vidaActual);

        // Puedes agregar aquí lógica adicional, como comprobar si el jugador ha perdido el juego, etc.
    }
    void AumentarVida(int cantidad)
    {
        vidaActual += cantidad;

        // Asegúrate de que la vida no sea mayor que el máximo
        vidaActual = Mathf.Min(vidaActual, vidaMaxima);

        Debug.Log("Vida actual: " + vidaActual);

        // Puedes agregar aquí lógica adicional, como comprobar si el jugador ha alcanzado la vida máxima, etc.
    }
}

