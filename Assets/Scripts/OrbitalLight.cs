using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalLight : MonoBehaviour
{    
    public float velocidadRotacion = 10f;
    public Light solecito;


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

        
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * velocidadRotacion * Time.deltaTime);
        solecito.transform.LookAt(transform.position);
        

        AplicarAjustesSegunRotacionZ();


    }

    private void AplicarAjustesSegunRotacionZ()
    {
        float rotacionZ = transform.eulerAngles.z;

        // Asegurarse de que la rotación esté entre 0 y 180
        rotacionZ = Mathf.Repeat(rotacionZ, 360f);  

        if (rotacionZ >= 0 && rotacionZ <= 100)
        {
            AjustesDeAmanecer();
        }
        else if (rotacionZ > 100 && rotacionZ <= 180)
        {
            AjustesDeMediodia();
        }
        else if (rotacionZ > 180 && rotacionZ <= 290)
        {
            AjustesDeAtardecer();
        }
        else if (rotacionZ > 290 && rotacionZ <= 360)
        {
            AjustesDeMedianoche();
        }
        
    }
    private void AjustesDeAmanecer()
    {
        solecito.intensity = 0.5f;
        solecito.color = Color.yellow;
        Debug.Log("AjustesDeAmanecer");
    }

    private void AjustesDeMediodia()
    {
        solecito.intensity = 1f;
        solecito.color = Color.white;
    }

    private void AjustesDeAtardecer()
    {
        solecito.intensity = 0.7f;
        solecito.color = new Color(1f, 0.5f, 0f); // Un tono de naranja
    }

    private void AjustesDeMedianoche()
    {
        solecito.intensity = 0.2f;
        solecito.color = Color.blue;
    }
}
