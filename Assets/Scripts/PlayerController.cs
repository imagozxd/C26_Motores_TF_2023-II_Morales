using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody rb;
    private Vector3 velocity;
    public float velocidadRotacion = 180f;


    private float rotacionY;
       

    //control energia del jugador
    public int vidaMaxima = 100;
    public int vidaActual;

    //detectar el barco
    private bool dentroDelBarco = false;

    public GameObject hacha;
    private Animator hachaAnim;

    //temas de audio xd
    public AudioSource playerAudio;    
    public AudioClip audioCaminar;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hachaAnim = hacha.GetComponent<Animator>();
        
        vidaActual = vidaMaxima;

    }
    private void Update()
    { 
    }
    private void FixedUpdate() 
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotacionY * Time.fixedDeltaTime, 0));

        // Aplica la rotación al vector de dirección del movimiento utilizando transform.forward
        Vector3 rotatedDirection = Quaternion.Euler(0, rotacionY * Time.fixedDeltaTime, 0) * transform.forward;
        rb.velocity = rotatedDirection * velocity.z;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        float directionMovement = context.ReadValue<float>() * velocidad;
        velocity = new Vector3(0, 0, directionMovement);
        
        if (directionMovement != 0f)
        {
            //enMovimiento = true;
            playerAudio.Play();
        }
        else
        {
            playerAudio.Stop();
        }

    }

    public void Direction(InputAction.CallbackContext context)
    {
        float directionRotate = context.ReadValue<float>();
        
        rotacionY = directionRotate * velocidadRotacion;

    }
    
    
    public void OnClic(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Tecla el boton del mouse ");
            
            hachaAnim.SetTrigger("talar");
        }
    }

    public void OnPressK(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Tecla presionada es K ");
            
        }
    }

    //public void TalarArbol()
    //{
    //    int bajarVida = 10; //cambiar por el metodo
    //    ReducirVida(bajarVida);
    //}
    //public void Comer()
    //{
    //    int subirVida = 10;
    //    AumentarVida(subirVida);
    //}
    
    
    public bool EstaDentroDelBarco()
    {
        return dentroDelBarco;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("barco"))
        {
            dentroDelBarco = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("barco"))
        {
            dentroDelBarco = false; 
        }
    }
     

   

}

