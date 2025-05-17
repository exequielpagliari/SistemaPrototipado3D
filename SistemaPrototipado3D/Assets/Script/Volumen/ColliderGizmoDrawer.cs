using UnityEngine;

[ExecuteAlways]
public class ColliderGizmoDrawer : MonoBehaviour
{
    public Color color = Color.cyan;
    private void OnDrawGizmos()
    {
        BoxCollider box = GetComponent<BoxCollider>();
        if (box == null) return;

        Gizmos.color = color;

        // Posición y rotación correctas incluso si no está centrado en el transform
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
