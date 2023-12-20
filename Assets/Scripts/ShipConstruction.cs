using UnityEngine;

public class ShipConstruction : MonoBehaviour
{
    public GameObject prefabMadera;    

    public GameObject[] shipStructureLevel;

    public bool gano { get; private set; } = false;
    private float tiempoActivo = 0f;

    private MiStack maderas = new MiStack(); // Usamos MiStack en lugar de Stack<GameObject>

    //public GameObject[] shipStructureLevel;

    public void AddMadera(int valorMadera)
    {
        for (int i = 0; i < valorMadera; i++)
        {
            maderas.Push(prefabMadera);
        }

        //Debug.Log("Cantidad de madera en la pila: " + maderas.Count);
        ModificarEstructuraBarco(); // Actualizar la estructura del barco después de agregar madera
    }

    public void RemoveMadera() // me esta quitando de 1 en 1
    {
        if (maderas.Count() > 0)
        {
            //maderasPerdidas = Random.Range(1, 5);

            maderas.Pop();
            ModificarEstructuraBarco(); // Actualizar la estructura del barco después de remover madera
            //Debug.Log("Cantidad de madera en la pila después de remover: " + maderas.Count);
        }
        else
        {
            Debug.LogWarning("No hay madera para remover.");
        }
    }

    public void ModificarEstructuraBarco()
    {
        if (shipStructureLevel != null)
        {
            // Actualizar el nivel de la estructura del barco según la cantidad de maderas
            if (maderas.Count() >= 0 && maderas.Count() < 10)
            {
                shipStructureLevel[0].SetActive(true);
                shipStructureLevel[1].SetActive(false);
                shipStructureLevel[2].SetActive(false);
            }
            else if (maderas.Count() >= 11 && maderas.Count() < 24)
            {
                shipStructureLevel[0].SetActive(false);
                shipStructureLevel[1].SetActive(true);
                shipStructureLevel[2].SetActive(false);
            }
            else if (maderas.Count() >= 25)
            {
                shipStructureLevel[0].SetActive(false);
                shipStructureLevel[1].SetActive(false);
                shipStructureLevel[2].SetActive(true);
            }
        }
    }

    //para el evento que retira maderas
    public void MaderasPerdidasPorDia()
    {if (maderas.Count() >5)
        {
            int valorRandom = Random.Range(1, 5);
            for (int i = 1; i < valorRandom; i++)
            {
                RemoveMadera();
                Debug.Log("SE ESTA PERDIENDO MADERAS LOCO");
            }
        }
    else
        {
            Debug.Log("OSEASEEEEE QUE NO HABIA MADERAS SUFICIENTES");
            return;
        }
    }

    private void Start()
    {
        // Apagar todos los modelos al inicio
        for (int i = 0; i < shipStructureLevel.Length; i++)
        {
            shipStructureLevel[i].SetActive(false);
        }

        TimeController.OnNuevoDia += MaderasPerdidasPorDia;
    }
    

private void Update()
    {
        ////  probando desde el inspector con una maderita zz 
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    // Agrega un valor arbitrario cada vez que se presiona la tecla espaciadora
        //    AddMadera(1);
        //}
        //Debug.Log("dddddddddddddddddddddddddddddd" + maderas.Count);
        if (shipStructureLevel[2].activeSelf)
        {
            // Si shipStructureLevel[2] está activo, aumentar el temporizador
            tiempoActivo += Time.deltaTime;

            // Si ha estado activo durante al menos 15 segundos, imprimir "gano"
            if (tiempoActivo >= 15f && !gano)
            {
                Debug.Log("¡Ganaste!");
                gano = true; // Evitar que se imprima múltiples veces
            }
        }
        else
        {
            // Si shipStructureLevel[2] no está activo, reiniciar el temporizador y el estado de ganar
            tiempoActivo = 0f;
            gano = false;
        }

        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    // Si se presiona la tecla "C", remover una madera
        //    RemoveMadera();
        //    Debug.Log("LA CANTIDAD DE MADERAS DEL BARCO" + maderas.Count());
        //}
    }
}

