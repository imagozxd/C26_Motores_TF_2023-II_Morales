using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    //public PlayerController player;

    public string resourceName;
    public Vector3 position;
    public int valueItem; //valor con el que directamente afectara al jugador, si es madera cuanto suma? si es vida cuanto le cura.

    // M�todo para interactuar con el recurso
    public virtual void Interact()
    {
        // L�gica base de interacci�n
        Debug.Log("Interacting with " + resourceName);
    }

}
