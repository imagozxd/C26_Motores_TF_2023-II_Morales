using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour
{
    public int vidaArbol;
    public int vidaActualArbol;
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
            Destroy(gameObject);
            
        }
    }
    
    public int ActualizarVida(int dmg)
    {
        vidaActualArbol -= dmg;

        Debug.Log("vida actual del arbolito " + gameObject.name + ": " + vidaActualArbol);
        return vidaActualArbol;
    }
}
