using UnityEngine;

[CreateAssetMenu(fileName = "NewScoreSO", menuName = "ScoreSO")]
public class ScoreSO : ScriptableObject
{
    public int dias;   

    // Variable para almacenar la fecha y hora de la última vez que se jugó
    public System.DateTime ultimaVezJugado;

    // Método para actualizar la fecha y hora actual cuando se actualiza el puntaje
    public void ActualizarUltimaVezJugado()
    {
        ultimaVezJugado = System.DateTime.Now;
    }

}
