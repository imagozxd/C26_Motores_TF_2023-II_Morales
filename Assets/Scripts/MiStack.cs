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

    // Método para verificar si la pila está vacía
    public bool EstaVacia()
    {
        return cabeza == null;
    }

    // Método para agregar un elemento a la pila
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

    // Método para quitar y devolver el elemento superior de la pila
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

    // Método para ver el elemento superior de la pila sin sacarlo
    public GameObject Peek()
    {
        if (EstaVacia())
        {
            throw new System.InvalidOperationException("La pila está vacía");
        }

        return cabeza.valor;
    }

    // Método para obtener la cantidad de elementos en la pila
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

