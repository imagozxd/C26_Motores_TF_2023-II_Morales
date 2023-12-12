using System.Collections;
using UnityEngine;

public class Pescado : MonoBehaviour
{
    private Rigidbody rb;

    public float forceHeight; // salto al aparecer
    
    public float gravity = 9.8f;

    private bool isElevating = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * forceHeight;
    }

    private void Update()
    {
        if (isElevating)
        {
            //aplicar gravedad
            rb.velocity = rb.velocity + Vector3.down * gravity * Time.deltaTime;

            
        }
        else
        {
            // llenar por si se me ocurre algo xd
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("terrain_tag"))
        {
            isElevating = false;
            //rb.isKinematic = false;
            Debug.Log("Se detiene el salto");
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Inventario inventario = collision.gameObject.GetComponent<Inventario>();
            inventario.cantidadMadera++;
            Debug.Log("entra en colision madera <> player // +madera a inventario");


            Destroy(this.gameObject);  // destruye la madera

        }
    }
}

