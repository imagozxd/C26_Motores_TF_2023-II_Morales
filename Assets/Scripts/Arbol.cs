using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour
{
    public int vidaArbol;
    public int vidaActualArbol;
    public GameObject prefabArbolTalada;
    public GameObject tablasMadera;
    public int cantidadTablasMadera;

    private Weapon arma;


    private void Start()
    {
        vidaActualArbol = vidaArbol;
        arma = GetComponent<Weapon>();
    }

    private void Update()
    {        
        if (vidaActualArbol <= 0)
        {   
            Vector3 posicion = transform.position;   // aqui saco la posicion del arbol especifico

            Destroy(gameObject);
            Debug.Log(CantidadDrop());

            for (int i = 0; i < CantidadDrop(); i++)
            {
                Debug.Log("DROPEANDO MADERAS");
                Instantiate(tablasMadera, posicion, Quaternion.identity);
            }
            Instantiate(prefabArbolTalada, posicion, Quaternion.Euler(-90, 0, 0));
        }
    }
    
    public int ActualizarVida(int dmg)
    {
        vidaActualArbol -= dmg;

        Debug.Log("vida actual del arbolito " + gameObject.name + ": " + vidaActualArbol);
        return vidaActualArbol;
    }
    public int CantidadDrop()
    {
        cantidadTablasMadera = Random.Range(2, Mathf.CeilToInt(vidaArbol / 6f));

        return cantidadTablasMadera;
    }
}
