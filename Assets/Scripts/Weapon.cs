using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Weapon : MonoBehaviour
{    
    public int cantidadDanio = 10;
    public int danioReal;
    
    public Arbol arbol;
    public bool isAttack = false;
    public GameObject hacha;
    Animator animatorHacha;

    //private bool isAnimationPlaying = false;
    private AudioSource audioPadre;
    public AudioClip audioTalado;

    private void Start()
    {
        animatorHacha = hacha.GetComponentInParent<Animator>();
        Debug.Log("nombre del animator del hacha:" +    animatorHacha.name);
        audioPadre = transform.parent.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("arbol")) 
        {
            danioReal = Random.Range((cantidadDanio /2)+Random.Range(0,10), cantidadDanio + Random.Range(0, 10));
            arbol = other.GetComponent<Arbol>();

            //auido de talado
            //audioPadre.PlayOneShot(audioTalado);
            
            if (arbol != null)
            {
                
                Debug.Log("ASDSADASDA");
                arbol.ActualizarVida(danioReal);
               Debug.Log("vida del arbol objetivo: " + arbol.vidaActualArbol);
            }
            

            Debug.Log("Desde weapon: " + danioReal);
        }

            }
    private void Update()
    {
        
    }

}
