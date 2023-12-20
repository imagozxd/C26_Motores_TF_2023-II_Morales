using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float duracionDia = 20f; // modificar a 210

    public float tiempoActual = 0f; // nomas para verlo desde el inspector como avanza ksj

    private int diasTranscurridos = 0;

    public ScoreSO scoreSO;


    public delegate void NuevoDiaEventHandler();
    public static event NuevoDiaEventHandler OnNuevoDia;
    
    public static event NuevoDiaEventHandler OnAmanecer;
    public static event NuevoDiaEventHandler OnMediodia;
    public static event NuevoDiaEventHandler OnAtardecer;
    public static event NuevoDiaEventHandler OnMedianoche;

    private void Update()
    {
        tiempoActual += Time.deltaTime;

        if (tiempoActual >= duracionDia)
        {
            tiempoActual = 0f;
            diasTranscurridos++;

            //Actualizar el ScoreSO
            scoreSO.dias = diasTranscurridos;

            // Guardar el nuevo intento en la tabla
            GuardarIntentoEnTabla(diasTranscurridos);

            Debug.Log("cambio de dia");
            DispararEventoNuevoDia();
            DeterminarMomentoDelDia();
        }
    }
    private void GuardarIntentoEnTabla(int dias)
    {
        string filePath = Application.persistentDataPath + "/tabla.txt";

        // Crear o abrir el archivo
        StreamWriter writer = new StreamWriter(filePath, true);

        // Escribir el número de días en una nueva línea
        writer.WriteLine(dias);

        // Cerrar el archivo
        writer.Close();
    }
    public void ImprimirTabla()
    {
        string filePath = Application.persistentDataPath + "/tabla.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                Debug.Log(line);
            }
        }
        else
        {
            Debug.Log("La tabla no existe.");
        }
    }

    void DispararEventoNuevoDia()
    {
        if (OnNuevoDia != null)
        {
            OnNuevoDia();
        }
    }

    void DeterminarMomentoDelDia()
    {
        // Puedes ajustar estos valores según la duración de cada período del día
        float porcentajeDia = tiempoActual / duracionDia;

        if (porcentajeDia >= 0f && porcentajeDia < 0.25f)
        {
            if (OnAmanecer != null)
            {
                OnAmanecer();
            }
        }
        else if (porcentajeDia >= 0.25f && porcentajeDia < 0.5f)
        {
            if (OnMediodia != null)
            {
                OnMediodia();
            }
        }
        else if (porcentajeDia >= 0.5f && porcentajeDia < 0.75f)
        {
            if (OnAtardecer != null)
            {
                OnAtardecer();
            }
        }
        else
        {
            if (OnMedianoche != null)
            {
                OnMedianoche();
            }
        }
    }
}
