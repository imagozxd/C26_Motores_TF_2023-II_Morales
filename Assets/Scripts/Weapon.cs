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

    // M�todo para talar �rboles
    //void TalarArbol(NotEdible arbol)
    //{
    //    // Reducir la vida del �rbol utilizando la cantidad de da�o
    //    arbol.RecibirDanio(cantidadDanio);

    //    // Puedes agregar l�gica adicional aqu�, como reproducir un sonido, mostrar efectos, etc.

    //    Debug.Log("�rbol da�ado. Vida actual del �rbol: " + arbol.GetCurrentHpTree());

    //    // Puedes verificar si el �rbol se queda sin vida y realizar acciones adicionales si es necesario
    //    if (arbol.GetCurrentHpTree() <= 0)
    //    {
    //        // �rbol talado, realiza acciones adicionales si es necesario
    //        Debug.Log("�rbol talado");
    //        // Puedes instanciar el prefab del �rbol talado u otras acciones aqu�
    //    }
    //}
}
