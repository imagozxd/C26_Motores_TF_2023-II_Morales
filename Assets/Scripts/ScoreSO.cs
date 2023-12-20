using UnityEngine;

[CreateAssetMenu(fileName = "NewScoreSO", menuName = "ScoreSO")]
public class ScoreSO : ScriptableObject
{
    public int dias;

    //public int Dias
    //{
    //    get { return dias; }
    //}

    // Método para actualizar la cantidad de días
    public void ActualizarDias(int nuevosDias)
    {
        dias = nuevosDias;
    }
}
