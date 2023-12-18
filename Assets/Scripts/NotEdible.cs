using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class NotEdible : Resources
{
    // detalles de cosas NO COMESTIBLES
    //public string requiredTool; // Herramienta necesaria para recolectar el recurso
    public GameObject treePrefab; // spawn de arboles
    public GameObject choppedTreePrefab; // prefab de arbol talado
    public int limiteArbolesGlobal;
    //public int hpTree;
    //public int currentHpTree; // deberia ser privado                     YA NO DEBERIAN ESTAR ACA, NOS VAMOS A UN SCRIPT SOLITO 

    public Vector3 treeSpawn = new Vector3 (0, 0, 0);  //declara el punto central de la zona spawn 
    public float radiusSpawn = 0;

    // una lista para almacenar la cantidad de ref de arboles instanciados
    private List<GameObject> spawnedTrees = new List<GameObject>();

    public int initialTreeCount; // cantidad inicial, PROBAR    



    private void Start()
    {
        //establecer la vida maxima de los arboles
        //currentHpTree = hpTree;

        SpawnInitialTrees();
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnInitialTrees();
        //    Debug.Log("la cantidad de arboles existente: " + GetspawnedTreeCount());
        //}
    }
    
    void SpawnInitialTrees()
    {
        Debug.Log("llamo al evento spawn");
        if(GetspawnedTreeCount () >= limiteArbolesGlobal)
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
            GameObject newTree = Instantiate(treePrefab, randomPosition, Quaternion.Euler(-90, 0, Random.Range(-90, 90))); // euler porque sino sale acostado
            spawnedTrees.Add(newTree); // se agrega a la lista
            //Debug.Log("pos del arbol spameado: " + randomPosition);

            newTree.transform.SetParent(this.transform); // para hacerlos hijos

        }
        //Debug.Log("cantidad de " + resourceName + " :" + GetspawnedTreeCount());

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
            // No hay colisi�n o la colisi�n es con un objeto que tiene el tag correcto, entonces podemos instanciar el �rbol
            Debug.Log("toca un arbol");
            return true;
        }
        Debug.Log("no hay arbol, crea uno");
        return false;
        
    }
        
    // M�todo para interactuar con el recurso no comestible
    public override void Interact()
    {
        base.Interact();
                
        Instantiate(treePrefab, position, Quaternion.Euler(-90,0,0));
    }

    public int GetspawnedTreeCount() // clavee
    {
        return spawnedTrees.Count; 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerDamage = GetComponent<PlayerController>();
            Debug.Log("esto es playerDamage:"+ playerDamage);
            Debug.Log("colision desde arbol hacia player");
        }
    }


    //suscripcion
    private void OnEnable()
    {
        TimeController.OnNuevoDia += SpawnInitialTrees;
    }
    private void OnDisable()
    {
        // Anular la suscripci�n al evento cuando el objeto se deshabilita o destruye
        TimeController.OnNuevoDia -= SpawnInitialTrees;
    }
    
}
