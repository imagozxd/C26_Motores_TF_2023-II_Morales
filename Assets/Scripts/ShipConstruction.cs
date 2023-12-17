using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class ShipConstruction : MonoBehaviour
{
    //public int valorMadera = 1;  // valor de la madera
    public GameObject prefabMadera;

    public Transform deck;    // punto para hacer la collision y "entregar" las maderas

    private Stack<GameObject> maderas = new Stack<GameObject>();  // pila que no se bien si deberia ser pila xd

    public GameObject[] shipStructureLevel;
    
    public void AddMadera(int valorMadera)
    {
        for (int i = 0; i < valorMadera; i++)
        {
            maderas.Push(prefabMadera);
            
        }
        
        
        Debug.Log("Cantidad de madera en la pila: " + maderas.Count);
    }

    public void RemoveMadera() //asocial a evento cuando acabe la noche o empiece un nuevo dia , quitar maderas
    {
        if (maderas.Count > 0)
        {
            // pop para sacar las de arriba
            GameObject maderaRemovida = maderas.Pop();

            // actualizar estructura
            ModificarEstructuraBarco();

            // print cantidad de maderas
            Debug.Log("Cantidad de madera en la pila después de remover: " + maderas.Count);
        }
        else
        {
            // print
            Debug.LogWarning("No hay madera para remover.");
        }
    }

    public void ModificarEstructuraBarco()
    {
        if(shipStructureLevel != null )
        {
            // actualizar el nivel de la estrutura del barco
            if (maderas.Count >= 0 && maderas.Count < 10)
            {
                Debug.Log("SSSSSSSSSSSSSSSSSSSSSSSS" + maderas.Count);
                Debug.Log("YYYYYY" + shipStructureLevel[0].name);
                shipStructureLevel[0].SetActive(true);
                shipStructureLevel[1].SetActive(false);
                shipStructureLevel[2].SetActive(false);
            }
            else if (maderas.Count >= 11 && maderas.Count < 24)
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
        
    }
    private void Start()
    {
        // apagar todos los modelos al inicir 
        for (int i = 0; i < shipStructureLevel.Length; i++)
        {
            shipStructureLevel[i].SetActive(false);
        }
        Debug.Log("se apago todo");
    }
    private void Update()
    {
        //  probando desde el inspector con una maderita zz 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Agrega un valor arbitrario cada vez que se presiona la tecla espaciadora
            AddMadera(1);
        }
        Debug.Log("dddddddddddddddddddddddddddddd" + maderas.Count);
    }
}

