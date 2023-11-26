using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edible : Resources
{
    // Propiedades específicas de recursos comestibles
    public int healthRestoreAmount;
    public GameObject pecesitoPrefab;

    // Método para interactuar con el recurso comestible
    public override void Interact()
    {
        base.Interact();
        // Lógica específica de recursos comestibles
        Debug.Log("Eating " + resourceName + " restores " + healthRestoreAmount + " health.");
        // Aquí podrías agregar lógica para afectar la salud del jugador

        Instantiate(pecesitoPrefab, position, Quaternion.identity);
        Debug.Log("creame un pecesito!");
    }
}
