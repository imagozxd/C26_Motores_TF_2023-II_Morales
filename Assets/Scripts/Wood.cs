using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private Rigidbody rb;
    public float forceHeight; // salto al aparecer
    public float rotationSpeed; // velocidad de rotacion
    public float gravity = 9.8f;

    private bool isElevating = true;

     

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0.5f, Random.Range(-1f, 1f)).normalized;
        // Aplicar la fuerza hacia arriba con la direcci�n aleatoria
        rb.velocity = randomDirection * forceHeight;
    }
    private void Update()
    {
        if (isElevating)
        {
            //aplicar gravedad
            rb.velocity = rb.velocity + Vector3.down* gravity * Time.deltaTime;

            transform.Rotate(Vector3.up, Random.Range(-rotationSpeed, rotationSpeed) * Time.deltaTime);
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
           //rb.isKinematic = false; // ojito aqui 
            Debug.Log("se detiene isElevating, deberia detenerse la madera en el suelo");
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
