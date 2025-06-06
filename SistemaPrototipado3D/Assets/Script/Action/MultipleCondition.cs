using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Prototipe.Core.Interfaces;

/// <summary>
/// Clase dedicada a manejar condiciones para realizar acciones.
/// </summary>
public class MultipleCondition : MonoBehaviour, ICondition
{
    /// <summary>
    /// Lista de condiciones utilizadas para la acci�n.
    /// </summary>
    public List<ICondition> conditions;
    /// <summary>
    /// Boleano de comprobaci�n.
    /// </summary>
    public bool IsMet()
    {
        return conditions.All(c => c != null && c.IsMet());
    }
}

