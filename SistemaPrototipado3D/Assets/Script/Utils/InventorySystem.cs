
using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Clase singleton simplificada dedicada a la manipualaci�n de inventario.
/// </summary>
public class InventorySystem : MonoBehaviour
{
    /// <summary>
    /// Referencia est�tica para singleton.
    /// </summary>
    public static InventorySystem Instance { get; private set; }

    /// <summary>
    /// Lista de string para inventariar.
    /// </summary>
    public List<String> inventoryNames = new List<String>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// M�todo para detectar la presencia de determinado String.
    /// </summary>
    public bool HasItem(String itemName)
    { return inventoryNames.Contains(itemName); }
    /// <summary>
    /// M�todo para agregar determinado String.
    /// </summary>
    public void AddItem(String itemName)
    { inventoryNames.Add(itemName); }
    /// <summary>
    /// M�todo para detectar remover de determinado String.
    /// </summary>
    public void RemoveItem(String itemName)
    { inventoryNames.Remove(itemName); }
}
