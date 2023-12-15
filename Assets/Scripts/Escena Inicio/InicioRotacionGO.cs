using UnityEngine;

public class RotacionObjeto : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    public float velocidadRotacion = 45f;  // lo necesito para 2 cosas mas. public


    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * velocidadRotacion * Time.deltaTime);
    }
}

