using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class SceneViewExample
{
    // Se suscribe automáticamente al evento cuando se carga el editor
    static SceneViewExample()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        // Dibujo de un botón en el centro de la escena
        Handles.BeginGUI();

        // Posición del botón
        Rect buttonRect = new Rect(10, 10, 100, 30);
        if (GUI.Button(buttonRect, "Haz click"))
        {
            Debug.Log("¡Botón en Scene View clickeado!");
        }

        Handles.EndGUI();

        // Ejemplo: dibujar un círculo en el origen del mundo
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(Vector3.zero, Vector3.up, 1f);
    }
}
