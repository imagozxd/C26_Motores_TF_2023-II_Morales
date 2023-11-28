using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NotEdible : Resources
{
    // detalles de cosas NO COMESTIBLES
    public string requiredTool; // Herramienta necesaria para recolectar el recurso
    public GameObject treePrefab; // spawn de arboles 

    public Vector3 treeSpawn = new Vector3 (0, 0, 0);  //declara el punto central de la zona spawn 
    public float radiusSpawn = 0;

    // una lista para almacenar la cantidad de ref de arboles instanciados
    private List<GameObject> spawnedTrees = new List<GameObject>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomPosition = GetRandomPosition();
            if (!HasCollision(randomPosition))
            {
                 GameObject newTree =  Instantiate(treePrefab, randomPosition, Quaternion.Euler(-90, 0, Random.Range(-90,90))); // euler porque sino sale acostado
                spawnedTrees.Add(newTree); // se agrega a la lista
                Debug.Log("pos del arbol spameado: " + randomPosition);                                                                      

            }
            Debug.Log(GetspawnedTreeCount());
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * radiusSpawn; //  insideUnitCircle crea un circulo unitario en el plano 
        return new Vector3(randomCircle.x, 0f, randomCircle.y) + treeSpawn;
    }
    private void OnDrawGizmos()
    {
        //DrawCircle();
        Gizmos.color = Color.red; // zona de spawn arboles
        Gizmos.DrawWireSphere(transform.position + treeSpawn, radiusSpawn);        

    }
    

    bool HasCollision (Vector3 position)
    {
        Ray ray = new Ray(position + Vector3.up * 20f, Vector3.down);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 20f, Color.yellow);

        if (!Physics.Raycast(ray, out hit, Mathf.Infinity) || hit.collider.CompareTag("top_tree"))
        {
            // No hay colisión o la colisión es con un objeto que tiene el tag correcto, entonces podemos instanciar el árbol
            Debug.Log("toca un arbol");
            return true;
        }
        Debug.Log("no hay arbol, crea uno");
        return false;
        
    }
        
    // Método para interactuar con el recurso no comestible
    public override void Interact()
    {
        base.Interact();
        // Lógica específica de recursos no comestibles
        Debug.Log(resourceName + " requires a " + requiredTool + " to gather.");
        // Aquí podrías agregar lógica para recolectar el recurso no comestible
        
        Instantiate(treePrefab, position, Quaternion.Euler(-90,0,0));
    }

    public int GetspawnedTreeCount()
    {
        return spawnedTrees.Count; 
    }
}
