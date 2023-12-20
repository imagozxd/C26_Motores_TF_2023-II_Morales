using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControlShark : MonoBehaviour
{
    public Shark tiburon;
    public GameObject[] arrayNodeControl;

    
    private void Start()    
    {
        tiburon.SetPositionDestiny(arrayNodeControl[tiburon.grafoPosicion].transform.position);
    }

    private void Update()
    {        
        tiburon.SetPositionDestiny(arrayNodeControl[tiburon.grafoPosicion].transform.position);
        tiburon.LookAt();
    }
    
}
