using UnityEngine;
using System.Collections.Generic;

public class ActivatorGizmo : MonoBehaviour
{
    [Header("Objetos a activar")]
    public List<MonoBehaviour> actions = new(); // Deben implementar IAction

    [Header("Opciones de visualización")]
    public Color lineColor = Color.green;
    public Color labelColor = Color.white;
    public Vector3 labelOffset = Vector3.up * 1.5f;

    private void OnDrawGizmos()
    {
        if (actions == null) return;

        Gizmos.color = lineColor;

        foreach (var action in actions)
        {
            if (action == null) continue;

            Vector3 from = transform.position;
            Vector3 to = action.transform.position;

            // Línea entre activador y acción
            Gizmos.DrawLine(from, to);

            // Esfera al final
            Gizmos.DrawSphere(to, 0.1f);

            // Etiqueta
#if UNITY_EDITOR
            UnityEditor.Handles.color = labelColor;
            UnityEditor.Handles.Label(to + labelOffset, action.GetType().Name);
#endif
        }
    }
}
