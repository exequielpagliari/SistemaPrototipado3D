using System.Collections.Generic;
using UnityEngine; 



/// <summary>
/// Provee m�todos de utilidad est�ticos para depuraci�n.
/// </summary>
public static class DebugUtilities // Haz la clase 'static'
{
    /// <summary>
    /// Imprime el contenido de cualquier diccionario (mapa) en la consola de Unity.
    /// </summary>
    /// <typeparam name="TKey">El tipo de las claves del diccionario.</typeparam>
    /// <typeparam name="TValue">El tipo de los valores del diccionario.</typeparam>
    /// <param name="dictionary">El diccionario que quer�s imprimir.</param>
    /// <param name="title">Un t�tulo opcional para el log, para ayudar a identificarlo.</param>
    public static void DebugSimpleDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, string title = "")
    {
        // Imprime un t�tulo si se proporciona para organizar la consola
        if (!string.IsNullOrEmpty(title))
        {
            Debug.Log($"--- DEBUG: {title} ---");
        }
        else
        {
            Debug.Log("--- DEBUG: Diccionario ---");
        }

        // Verifica si el diccionario es nulo o est� vac�o para evitar errores
        if (dictionary == null)
        {
            Debug.Log("El diccionario es nulo.");
            return;
        }

        if (dictionary.Count == 0)
        {
            Debug.Log("El diccionario est� vac�o.");
            return;
        }

        // Recorre cada par clave-valor en el diccionario e impr�melo
        foreach (KeyValuePair<TKey, TValue> entry in dictionary)
        {
            Debug.Log($"Clave: {entry.Key} | Valor: {entry.Value}");
        }

        Debug.Log("--- FIN DEBUG ---");
    }
}