using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public string resourceName;
    public Vector3 position;
    public int valueItem;

    // M�todo para interactuar con el recurso
    public virtual void Interact()
    {
        // L�gica base de interacci�n
        Debug.Log("Interacting with " + resourceName);
    }

}
