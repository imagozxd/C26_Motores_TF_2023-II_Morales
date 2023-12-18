using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiStack
{
    private class Nodo
    {
        public GameObject valor; 
        public Nodo siguiente; 

        public Nodo(GameObject val)
        {
            valor = val;
            siguiente = null;
        }
    }

    private Nodo cabeza; 

    public bool EstaVacia()
    {
        return cabeza == null;
    }

    //pa agregar
    public void Push(GameObject val)
    {
        Nodo nuevoNodo = new Nodo(val);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            nuevoNodo.siguiente = cabeza;
            cabeza = nuevoNodo;
        }
    }

    // pa quitar
    public GameObject Pop()
    {
        if (EstaVacia())
        {
            throw new System.InvalidOperationException("La pila está vacía");
        }

        GameObject valorSacado = cabeza.valor;
        cabeza = cabeza.siguiente;
        return valorSacado;
    }

    // conocer el ultimo, me puede servir
    public GameObject Peek()
    {
        if (EstaVacia())
        {
            throw new System.InvalidOperationException("La pila está vacía");
        }

        return cabeza.valor;
    }

    // cantidad
    public int Count()
    {
        int contador = 0;
        Nodo actual = cabeza;
        while (actual != null)
        {
            contador++;
            actual = actual.siguiente;
        }
        return contador;
    }
}

