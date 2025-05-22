using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Clase dedicada a manejar condiciones para realizar acciones.
/// </summary>
public class MultipleCondition : MonoBehaviour, ICondition
{
    /// <summary>
    /// Lista de condiciones utilizadas para la acción.
    /// </summary>
    public List<ICondition> conditions;
    /// <summary>
    /// Boleano de comprobación.
    /// </summary>
    public bool IsMet()
    {
        return conditions.All(c => c != null && c.IsMet());
    }
}

