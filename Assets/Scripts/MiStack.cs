using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiStack
{
    private class Nodo
    {
        public GameObject valor; // El GameObject almacenado en el nodo
        public Nodo siguiente; // El siguiente nodo en la pila

        public Nodo(GameObject val)
        {
            valor = val;
            siguiente = null;
        }
    }

    private Nodo cabeza; // El nodo en la parte superior de la pila

    // M�todo para verificar si la pila est� vac�a
    public bool EstaVacia()
    {
        return cabeza == null;
    }

    // M�todo para agregar un elemento a la pila
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

    // M�todo para quitar y devolver el elemento superior de la pila
    public GameObject Pop()
    {
        if (EstaVacia())
        {
            throw new System.InvalidOperationException("La pila est� vac�a");
        }

        GameObject valorSacado = cabeza.valor;
        cabeza = cabeza.siguiente;
        return valorSacado;
    }

    // M�todo para ver el elemento superior de la pila sin sacarlo
    public GameObject Peek()
    {
        if (EstaVacia())
        {
            throw new System.InvalidOperationException("La pila est� vac�a");
        }

        return cabeza.valor;
    }

    // M�todo para obtener la cantidad de elementos en la pila
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

