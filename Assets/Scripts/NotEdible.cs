using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class NotEdible : Resources
{
    public GameObject treePrefab; // spawn de arboles
    public GameObject choppedTreePrefab; // prefab de arbol talado
    public int limiteArbolesGlobal;
    
    //public int currentHpTree; // deberia ser privado                     YA NO DEBERIAN ESTAR ACA, NOS VAMOS A UN SCRIPT SOLITO 

    public Vector3 treeSpawn = new Vector3 (0, 0, 0);  //declara el punto central de la zona spawn 
    public float radiusSpawn = 0;

    private MiListaEnlazada<GameObject> spawnedTrees = new MiListaEnlazada<GameObject>();


    public int initialTreeCount; // cantidad inicial, PROBAR    



    private void Start()
    {
        SpawnInitialTrees();
    }
    private void Update()
    {

    }

    void SpawnInitialTrees()
    {
        Debug.Log("llamo al evento spawn");
        if (GetSpawnedTreeCount() >= limiteArbolesGlobal)
        {
            Debug.Log("full de arboles");
            return;
        }
        for (int i = 0; i < initialTreeCount; i++)
        {
            SpawnTree();
        }
    }

    void SpawnTree()
    {
        Vector3 randomPosition = GetRandomPosition();
        if (!HasCollision(randomPosition))
        {
            GameObject newTree = Instantiate(treePrefab, randomPosition, Quaternion.Euler(-90, 0, Random.Range(-90, 90)));
            spawnedTrees.Agregar(newTree); // Cambio el método Add a Agregar

            newTree.transform.SetParent(this.transform);
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
                
        Instantiate(treePrefab, position, Quaternion.Euler(-90,0,0));
    }

    public MiListaEnlazada<GameObject> GetSpawnedTrees()
    {
        return spawnedTrees;
    }

    // Cambio el nombre del método y el tipo de retorno
    public int GetSpawnedTreeCount()
    {
        return spawnedTrees.ContarElementos();
    }


    //suscripcion
    private void OnEnable()
    {
        TimeController.OnNuevoDia += SpawnInitialTrees;
    }
    private void OnDisable()
    {
        // Anular la suscripción al evento cuando el objeto se deshabilita o destruye
        TimeController.OnNuevoDia -= SpawnInitialTrees;
    }
    
}
