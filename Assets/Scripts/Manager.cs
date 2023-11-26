using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour

{
    public Edible edibleObject; // Arrastra el GameObject con el script Edible adjunto aqu� en el Inspector
    public NotEdible notEdibleObject;
    void Start()
    {
        // Llamada al m�todo Interact de la clase Edible
        edibleObject.Interact();
        notEdibleObject.Interact();
    }
}

