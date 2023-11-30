using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventarioItem
{
    public string nombre;
    public int cantidad;

    public InventarioItem(string nombre, int cantidad)
    {
        this.nombre = nombre;
        this.cantidad = cantidad;
    }
}

public class Inventario
{
    public List<InventarioItem> items = new List<InventarioItem>();

    // Añadir un elemento al inventario
    public void AddItem(string nombre, int cantidad)
    {
        InventarioItem newItem = new InventarioItem(nombre, cantidad);
        items.Add(newItem);
    }

    // Quitar un elemento del inventario
    public void RemoveItem(string nombre)
    {
        InventarioItem itemToRemove = items.Find(item => item.nombre == nombre);
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
        }
    }

    // Mostrar el inventario en la consola (solo para propósitos de demostración)
    public void MostrarInventario()
    {
        foreach (var item in items)
        {
            Debug.Log($"Item: {item.nombre}, Cantidad: {item.cantidad}");
        }
    }
}
