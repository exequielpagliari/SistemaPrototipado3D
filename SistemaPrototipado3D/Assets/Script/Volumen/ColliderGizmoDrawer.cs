using UnityEngine;

[ExecuteAlways]
/// <summary>
/// Clase dedicada al dibujado de Colliders en el Editor.
/// </summary>
public class ColliderGizmoDrawer : MonoBehaviour
{
    /// <summary>
    /// Color a representar el Gizmo del Collider.
    /// </summary>
    public Color color = Color.cyan;
    private void OnDrawGizmos()
    {
        BoxCollider box = GetComponent<BoxCollider>();
        if (box == null) return;

        Gizmos.color = color;

        // Posici�n y rotaci�n correctas incluso si no est� centrado en el transform
        Matrix4x4 oldMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(
            box.transform.position + box.center,
            box.transform.rotation,
            box.transform.lossyScale
        );

        Gizmos.DrawWireCube(Vector3.zero, box.size);
        Gizmos.matrix = oldMatrix;
    }
}
