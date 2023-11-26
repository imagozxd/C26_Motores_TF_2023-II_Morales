using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edible : Resources
{
    // Propiedades espec�ficas de recursos comestibles
    public int healthRestoreAmount;
    public GameObject pecesitoPrefab;

    // M�todo para interactuar con el recurso comestible
    public override void Interact()
    {
        base.Interact();
        // L�gica espec�fica de recursos comestibles
        Debug.Log("Eating " + resourceName + " restores " + healthRestoreAmount + " health.");
        // Aqu� podr�as agregar l�gica para afectar la salud del jugador

        Instantiate(pecesitoPrefab, position, Quaternion.identity);
        Debug.Log("creame un pecesito!");
    }
}
