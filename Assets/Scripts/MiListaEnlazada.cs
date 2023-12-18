using UnityEngine;

public class MiListaEnlazada<T>
{
    private class Nodo
    {
        public T Valor; 
        public Nodo Siguiente; 

        public Nodo(T val)
        {
            Valor = val;
            Siguiente = null;
        }
    }

    private Nodo Cabeza; 

    // revisar vacia
    public bool EstaVacia()
    {
        return Cabeza == null;
    }

    public void Agregar(T val)
    {
        Nodo nuevoNodo = new Nodo(val);
        if (Cabeza == null)
        {
            Cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    public T ObtenerElemento(int indice)
    {
        if (EstaVacia())
        {
            throw new System.InvalidOperationException("La lista está vacía");
        }

        Nodo actual = Cabeza;
        int contador = 0;

        while (actual != null && contador < indice)
        {
            actual = actual.Siguiente;
            contador++;
        }

        if (actual == null)
        {
            throw new System.IndexOutOfRangeException("Índice fuera de rango");
        }

        return actual.Valor;
    }

    // cantidad
    public int ContarElementos()
    {
        int contador = 0;
        Nodo actual = Cabeza;
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }
}
