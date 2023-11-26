using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // entrada 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // calcular vector
        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        // calcular vector siguiente
        Vector3 newPosition = rb.position + movement * speed * Time.fixedDeltaTime;

        // actualizar posicion
        rb.MovePosition(newPosition);
    }
}

