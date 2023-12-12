using UnityEngine;

public class RotarObjeto : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    public float velocidadRotacion = 45f;  // lo necesito para 2 cosas mas. public

    void Update()
    {
        transform.Rotate(new Vector3(1,1,1) * velocidadRotacion * Time.deltaTime);
    }
}
