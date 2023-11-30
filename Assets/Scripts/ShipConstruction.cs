using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class ShipConstruction : MonoBehaviour
{
    public int valorMadera = 1;  // Valor de la madera
    public Transform deck;    // Transform del lugar donde se colocan las maderas en el barco

    private Stack<int> maderas = new Stack<int>();  // Pila para almacenar los valores de madera

    public GameObject[] shipStructureLevel;

    // Método para agregar un valor de madera a la pila y modificar la estructura del barco
    public void AddMadera(int valorMadera)
    {
        maderas.Push(valorMadera);
        ModificarEstructuraBarco();
        Debug.Log("Cantidad de madera en la pila: " + maderas.Count);
    }

    // Método para quitar un valor de madera de la pila y modificar la estructura del barco
    public void RemoveMadera()
    {
        if (maderas.Count > 0)
        {
            // Saca el valor de madera de la pila
            int maderaRemovida = maderas.Pop();

            // Llama a un método para modificar la estructura del barco
            ModificarEstructuraBarco();

            // Debug para imprimir la cantidad de madera en la pila después de remover
            Debug.Log("Cantidad de madera en la pila después de remover: " + maderas.Count);
        }
        else
        {
            Debug.LogWarning("No hay madera para remover.");
        }
    }

    // Método para modificar la estructura del barco según la cantidad de maderas
    private void ModificarEstructuraBarco()
    {
        // Determina el nivel de estructura a activar según el valor de valorMadera
        if (maderas.Count >= 0 && maderas.Count <= 10)
        {
            shipStructureLevel[0].SetActive(true);
            shipStructureLevel[1].SetActive(false);
            shipStructureLevel[2].SetActive(false);
        }
        else if (maderas.Count >= 11 && maderas.Count <= 24)
        {
            shipStructureLevel[0].SetActive(false);
            shipStructureLevel[1].SetActive(true);
            shipStructureLevel[2].SetActive(false);
        }
        else if (maderas.Count >= 25)
        {
            shipStructureLevel[0].SetActive(false);
            shipStructureLevel[1].SetActive(false);
            shipStructureLevel[2].SetActive(true);
        }
    }
    private void Start()
    {
        // Desactiva todos los niveles de estructura
        for (int i = 0; i < shipStructureLevel.Length; i++)
        {
            shipStructureLevel[i].SetActive(false);
        }
        Debug.Log("se apago todo");
    }
    private void Update()
    {
        // Puedes cambiar el valor 1 por cualquier valor que desees agregar en cada frame
        // Puedes usar Input.GetKey, Input.GetKeyDown o cualquier otro método para detectar cuándo agregar madera
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Agrega un valor arbitrario cada vez que se presiona la tecla espaciadora
            AddMadera(1);
        }
    }
}

