using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Shark : MonoBehaviour
{    
    private Vector3 refVelocity;
    public float timeToMove;

    public Vector3 posDestiny;
    public float speed;

    public int grafoPosicion = 0;
        

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posDestiny, Time.deltaTime * speed);


        //Debug.Log("CANTIDAD DE NODOS DE TIBURONES: " + nodeControl.arrayNodeControl.Length);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("NodeShark"))
        {
            grafoPosicion++;  
            if (grafoPosicion >9)
            {
                grafoPosicion = 0;
            }
           
        }
    }

    public void SetPositionDestiny(Vector3 pos)
    {
        posDestiny = pos;
    }
    public void LookAt()
    {
        transform.LookAt(posDestiny);
    }
}
