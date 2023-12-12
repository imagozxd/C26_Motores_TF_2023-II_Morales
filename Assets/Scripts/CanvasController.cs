using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Text contadorMadera;
    public GameObject jugador;
    Inventario inventario; 

    private void Start()
    {
        inventario = jugador.GetComponent<Inventario>();
        
    }

    private void Update()
    {
        contadorMadera.text = "x "+inventario.cantidadMadera.ToString();

        if (inventario.cantidadMadera < 0)
        {
            inventario.cantidadMadera = 0;
        }
        else if (inventario.cantidadMadera > 20)
        {
            inventario.cantidadMadera = 20;
        }

        if (inventario.cantidadMadera >= 20)
        {
            contadorMadera.color = Color.red;

            // Puedes agregar aquí lógica adicional si es necesario
        }
        else
        {
            contadorMadera.color = Color.white;
        }
    }
}
