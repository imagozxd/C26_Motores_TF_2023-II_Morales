using UnityEngine;

public class SelectMaterial : MonoBehaviour
{

    public CustomMaterial customMaterial;
    public int prueba = 0;
    public Renderer rend;
    public Material materialDelObjeto;
    void Start()
    {

        rend = GetComponent<Renderer>();
        materialDelObjeto = rend.material;
        
    }

    void Update()
    {
        materialDelObjeto.color = customMaterial.SetColor(prueba);
    }
}
