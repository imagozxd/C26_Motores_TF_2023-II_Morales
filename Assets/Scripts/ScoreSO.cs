using UnityEngine;

[CreateAssetMenu(fileName = "NewScoreSO", menuName = "ScoreSO")]
public class ScoreSO : ScriptableObject
{
    public int dias;

    //public int Dias
    //{
    //    get { return dias; }
    //}

    // M�todo para actualizar la cantidad de d�as
    public void ActualizarDias(int nuevosDias)
    {
        dias = nuevosDias;
    }
}
