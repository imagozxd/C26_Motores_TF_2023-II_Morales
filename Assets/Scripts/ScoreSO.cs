using UnityEngine;

[CreateAssetMenu(fileName = "NewScoreSO", menuName = "ScoreSO")]
public class ScoreSO : ScriptableObject
{
    public int dias;   

    // Variable para almacenar la fecha y hora de la �ltima vez que se jug�
    public System.DateTime ultimaVezJugado;

    // M�todo para actualizar la fecha y hora actual cuando se actualiza el puntaje
    public void ActualizarUltimaVezJugado()
    {
        ultimaVezJugado = System.DateTime.Now;
    }

}
