using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEdible : Resources
{
    // detalles de cosas NO COMESTIBLES
    public string requiredTool; // Herramienta necesaria para recolectar el recurso
    public GameObject tablaMadera;
    // Método para interactuar con el recurso no comestible
    public override void Interact()
    {
        base.Interact();
        // Lógica específica de recursos no comestibles
        Debug.Log(resourceName + " requires a " + requiredTool + " to gather.");
        // Aquí podrías agregar lógica para recolectar el recurso no comestible
        Instantiate(tablaMadera, position, Quaternion.identity); // poblema de ejes con el 3ds max tmr
        Instantiate(tablaMadera, position, Quaternion.Euler(-90,0,0));
    }
}
