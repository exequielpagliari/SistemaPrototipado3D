/*
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class SceneViewExample
{
    // Se suscribe autom�ticamente al evento cuando se carga el editor
    static SceneViewExample()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        // Dibujo de un bot�n en el centro de la escena
        Handles.BeginGUI();

        // Posici�n del bot�n
        Rect buttonRect = new Rect(10, 10, 100, 30);
        if (GUI.Button(buttonRect, "Haz click"))
        {
            Debug.Log("�Bot�n en Scene View clickeado!");
        }

        Handles.EndGUI();

        // Ejemplo: dibujar un c�rculo en el origen del mundo
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(Vector3.zero, Vector3.up, 1f);
    }
}
*/