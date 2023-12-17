using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float duracionDia = 20f; // modificar a 210

    private float tiempoActual = 0f;

    public delegate void NuevoDiaEventHandler();
    public static event NuevoDiaEventHandler OnNuevoDia;

    private void Update()
    {
        tiempoActual += Time.deltaTime;

        if(tiempoActual >= duracionDia)
        {
            tiempoActual = 0f;

            DispararEventoNuevoDia();
        }
        Debug.Log(tiempoActual);
    }

    void DispararEventoNuevoDia()
    {
        if (OnNuevoDia != null)
        {
            OnNuevoDia();
        }
    }
}
