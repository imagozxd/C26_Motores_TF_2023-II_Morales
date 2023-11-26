using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEdible : Resources
{
    // detalles de cosas NO COMESTIBLES
    public string requiredTool; // Herramienta necesaria para recolectar el recurso
    public GameObject treePrefab; // spawn de arboles 

    public Vector3 treeSpawn = new Vector3 (20f, 0, 20f);  //declara el punto central de la zona spawn 
    public float radiusSpawn = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomPosition = GetRandomPosition();
            if (!HasCollision(randomPosition))
            {
                Instantiate(treePrefab, randomPosition, Quaternion.Euler(-90, 0, 0)); // euler porque sino sale acostado 
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * radiusSpawn; //  insideUnitCircle crea un circulo unitario en el plano 
        return new Vector3(randomCircle.x, 0f, randomCircle.y) + treeSpawn;
    }

    bool HasCollision (Vector3 position)
    {
        Ray ray = new Ray(position + Vector3.up * 20f, Vector3.down);
        RaycastHit hit; 
        
        if (Physics.Raycast(ray, out hit))
        {
        return true;
        }
        return false;
    }
        
    // Método para interactuar con el recurso no comestible
    public override void Interact()
    {
        base.Interact();
        // Lógica específica de recursos no comestibles
        Debug.Log(resourceName + " requires a " + requiredTool + " to gather.");
        // Aquí podrías agregar lógica para recolectar el recurso no comestible
        //Instantiate(tablaMadera, position, Quaternion.identity); // poblema de ejes con el 3ds max tmr
        Instantiate(treePrefab, position, Quaternion.Euler(-90,0,0));
    }
}
