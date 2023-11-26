using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public string resourceName;
    public Vector3 position;
    public int valueItem;

    // Método para interactuar con el recurso
    public virtual void Interact()
    {
        // Lógica base de interacción
        Debug.Log("Interacting with " + resourceName);
    }

}
