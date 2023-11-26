using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour

{
    public Edible edibleObject; // Arrastra el GameObject con el script Edible adjunto aquí en el Inspector
    public NotEdible notEdibleObject;
    void Start()
    {
        // Llamada al método Interact de la clase Edible
        edibleObject.Interact();
        notEdibleObject.Interact();
    }
}

