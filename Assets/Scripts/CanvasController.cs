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
        contadorMadera.text = "x"+inventario.cantidadMadera.ToString();
    }
}
