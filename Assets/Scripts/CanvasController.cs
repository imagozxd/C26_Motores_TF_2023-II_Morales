using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Text contadorMadera;
    public GameObject jugador;
    public GameObject barcos;
    public Inventario inventario;
    public ShipConstruction shipConstruction;
    public PlayerController playerController;

    public Button _buttonEntregar;

    

    private void Start()
    {
        inventario = jugador.GetComponent<Inventario>();
        shipConstruction = barcos.GetComponent<ShipConstruction>();
        playerController= jugador.GetComponent<PlayerController>();

        _buttonEntregar.onClick.AddListener(() => BotonEntregar());

        //mostrar el boton en pantalla
        _buttonEntregar.gameObject.SetActive(false);

    }

    private void Update()
    {
        /////////////todo esto modifica solo el texto score de cantidad de maderas 
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
        ///////////////////////////////

        //verificar si esta dentro dle barco
        if (playerController.EstaDentroDelBarco())
        {
            _buttonEntregar.gameObject.SetActive(true);
        }
        else
        {
            _buttonEntregar.gameObject.SetActive(false);
        }
    }

    
    public void BotonEntregar()
    {
        //if (jugador != null && jugador.TryGetComponent<ShipConstruction>(out shipConstruction))
        //{
        //    Debug.Log("DESDE EL BOTON  " + inventario.cantidadMadera);
        //    shipConstruction.AddMadera(inventario.cantidadMadera);
        //}
        //else
        //{
        //    Debug.LogWarning("No se encontró el componente ShipConstruction en el jugador.");
        //}
        Debug.Log("DESDE EL BOTON  " + inventario.cantidadMadera);
        shipConstruction.AddMadera(inventario.cantidadMadera);
        shipConstruction.ModificarEstructuraBarco();
        inventario.cantidadMadera = 0;
        
    }

}
