using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{    
    public int cantidadDanio = 10;
    public int danioReal;
    
    public Arbol arbol; 
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("arbol")) 
        {
            danioReal = Random.Range((cantidadDanio /2)+Random.Range(0,10), cantidadDanio + Random.Range(0, 10));
            arbol = other.GetComponent<Arbol>();

            
            if (arbol != null)
            {
                
                Debug.Log("ASDSADASDA");
                arbol.ActualizarVida(danioReal);
               Debug.Log("vida del arbol objetivo: " + arbol.vidaActualArbol);
            }
            

            Debug.Log("Desde weapon: " + danioReal);
        }
    }

}
