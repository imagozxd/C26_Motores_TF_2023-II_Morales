using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalLight : MonoBehaviour
{    
    public float velocidadRotacion = 10f;
    public Light solecito;

    //public delegate void CambioDeMomentoDelDiaEventHandler();
    //public static event CambioDeMomentoDelDiaEventHandler OnAmanecer;
    //public static event CambioDeMomentoDelDiaEventHandler OnMediodia;
    //public static event CambioDeMomentoDelDiaEventHandler OnAtardecer;
    //public static event CambioDeMomentoDelDiaEventHandler OnMedianoche;


    private void Start()
    {
        solecito = GetComponentInChildren<Light>();
        if (solecito == null)
        {
            Debug.LogError("No se encontró el componente Light en los hijos.");
            
        }
        else
        {
            Debug.Log(solecito.name);
        }

        //suscritos T_T
        TimeController.OnAmanecer += AjustesDeAmanecer;
        TimeController.OnMediodia += AjustesDeMediodia;
        TimeController.OnAtardecer += AjustesDeAtardecer;
        TimeController.OnMedianoche += AjustesDeMedianoche;
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * velocidadRotacion * Time.deltaTime);
        solecito.transform.LookAt(transform.position);
    }

    private void AjustesDeAmanecer()
    {
        // Lógica para ajustes específicos al amanecer
        solecito.intensity = 0.5f;
        solecito.color = Color.yellow;
        Debug.Log("AjustesDeAmanecer");
    }

    private void AjustesDeMediodia()
    {
        // Lógica para ajustes específicos al mediodía
        solecito.intensity = 1f;
        solecito.color = Color.white;
    }

    private void AjustesDeAtardecer()
    {
        // Lógica para ajustes específicos al atardecer
        solecito.intensity = 0.7f;
        solecito.color = new Color(1f, 0.5f, 0f); // Un tono de naranja
    }

    private void AjustesDeMedianoche()
    {
        // Lógica para ajustes específicos a la medianoche
        solecito.intensity = 0.2f;
        solecito.color = Color.blue;
    }
}
