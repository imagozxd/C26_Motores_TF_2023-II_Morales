using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edible : Resources
{
    // Propiedades específicas de recursos comestibles
    public int healthRestoreAmount;
    public GameObject pecesitoPrefab;

    public Vector3 fishSpawn = new Vector3(0, 0, 0);  //declara el punto central de la zona spawn 

    public float lengthSpawn = 0;  // Ancho 
    public float widthSpawn = 0;   // Largo 
    //public float radiusSpawn = 0; // cambiar esto para un rectangulo zz

    private List<GameObject> spawnedFishes = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomPosition = GetRandomPosition();
            if (!HasCollision(randomPosition))
            {
                GameObject newEdible = Instantiate(pecesitoPrefab, randomPosition, Quaternion.Euler(-90, 0, Random.Range(-90, 90))); // euler porque sino sale acostado
                spawnedFishes.Add(newEdible); // se agrega a la lista
                Debug.Log("pos del arbol spameado: " + randomPosition);

                newEdible.transform.SetParent(this.transform);

            }
            Debug.Log("cantidad de " + resourceName + " :" + GetspawnedFishesCount());
        }
    }


    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-lengthSpawn / 2, lengthSpawn / 2) + fishSpawn.x;
        float randomZ = Random.Range(-widthSpawn / 2, widthSpawn / 2) + fishSpawn.z;

        return new Vector3(randomX, 0f, randomZ);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Vector3 center = transform.position + fishSpawn;
        Vector3 size = new Vector3(lengthSpawn, 0f, widthSpawn);

        Gizmos.DrawWireCube(center, size);
    }

    bool HasCollision(Vector3 position)
    {
        Ray ray = new Ray(position + Vector3.up * 20f, Vector3.down);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 20f, Color.yellow);

        if (!Physics.Raycast(ray, out hit, Mathf.Infinity) || hit.collider.CompareTag("top_fish"))
        {
            // si no hay colision con el tag, si instancia papu
            Debug.Log("toca un pescado");
            return true;
        }
        Debug.Log("no hay pescado, crea uno");
        return false;

    }
    public int GetspawnedFishesCount()
    {
        return spawnedFishes.Count;
    }

    public override void Interact()
    {
        base.Interact();
        
    }
}
