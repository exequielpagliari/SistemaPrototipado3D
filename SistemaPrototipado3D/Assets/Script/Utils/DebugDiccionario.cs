using System.Collections.Generic;
using UnityEngine; 



/// <summary>
/// Provee métodos de utilidad estáticos para depuración.
/// </summary>
public static class DebugUtilities // Haz la clase 'static'
{
    /// <summary>
    /// Imprime el contenido de cualquier diccionario (mapa) en la consola de Unity.
    /// </summary>
    /// <typeparam name="TKey">El tipo de las claves del diccionario.</typeparam>
    /// <typeparam name="TValue">El tipo de los valores del diccionario.</typeparam>
    /// <param name="dictionary">El diccionario que querés imprimir.</param>
    /// <param name="title">Un título opcional para el log, para ayudar a identificarlo.</param>
    public static void DebugSimpleDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, string title = "")
    {
        // Imprime un título si se proporciona para organizar la consola
        if (!string.IsNullOrEmpty(title))
        {
            Debug.Log($"--- DEBUG: {title} ---");
        }
        else
        {
            Debug.Log("--- DEBUG: Diccionario ---");
        }

        // Verifica si el diccionario es nulo o está vacío para evitar errores
        if (dictionary == null)
        {
            Debug.Log("El diccionario es nulo.");
            return;
        }

        if (dictionary.Count == 0)
        {
            Debug.Log("El diccionario está vacío.");
            return;
        }

        // Recorre cada par clave-valor en el diccionario e imprímelo
        foreach (KeyValuePair<TKey, TValue> entry in dictionary)
        {
            Debug.Log($"Clave: {entry.Key} | Valor: {entry.Value}");
        }

        Debug.Log("--- FIN DEBUG ---");
    }
}