using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{    
    public int cantidadDanio = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("arbol")) 
        {

            int danioReal = Random.Range((cantidadDanio /2)+Random.Range(0,10), cantidadDanio + Random.Range(0, 10));

            Debug.Log(danioReal);          
            
        }
    }

    // Método para talar árboles
    //void TalarArbol(NotEdible arbol)
    //{
    //    // Reducir la vida del árbol utilizando la cantidad de daño
    //    arbol.RecibirDanio(cantidadDanio);

    //    // Puedes agregar lógica adicional aquí, como reproducir un sonido, mostrar efectos, etc.

    //    Debug.Log("Árbol dañado. Vida actual del árbol: " + arbol.GetCurrentHpTree());

    //    // Puedes verificar si el árbol se queda sin vida y realizar acciones adicionales si es necesario
    //    if (arbol.GetCurrentHpTree() <= 0)
    //    {
    //        // Árbol talado, realiza acciones adicionales si es necesario
    //        Debug.Log("Árbol talado");
    //        // Puedes instanciar el prefab del árbol talado u otras acciones aquí
    //    }
    //}
}
