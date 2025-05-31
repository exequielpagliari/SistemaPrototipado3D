using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class DrawEventConnectionsGizmo
{
    
    static DrawEventConnectionsGizmo()
    {
        ManagerEditorPrefs.Load();
        SceneView.duringSceneGui += OnSceneGUI;
        SceneView.beforeSceneGui += OutScene;
    }

    private static void OutScene(SceneView view)
    {
        ManagerEditorPrefs.Save();
    }


    private static void OnSceneGUI(SceneView view)
    {
        // Dibujo de un botón en el centro de la escena
        Handles.BeginGUI();

        // Posición del botón
        Rect buttonRect = new Rect(10, 10, 125, 30);
        if (GUI.Button(buttonRect, "Debug EventCanals"))
        {
            ManagerEditorPrefs.SetDebug(!ManagerEditorPrefs.GetDebug());
        }

        Handles.EndGUI();

        if(ManagerEditorPrefs.GetDebug())
        {
        var allObjects = GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

        Dictionary<object, List<MonoBehaviour>> channelMap = new();

        foreach (var obj in allObjects)
        {
            var type = obj.GetType();
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var attr = Attribute.GetCustomAttribute(field, typeof(DrawEventConnection)) as DrawEventConnection;
                if (attr == null) continue;

                var value = field.GetValue(obj);
                if (value == null) continue;

                if (!channelMap.ContainsKey(value))
                    channelMap[value] = new List<MonoBehaviour>();

                channelMap[value].Add(obj);
            }
        }

        Handles.color = new Color(0,1,0,.5f);
            foreach (var kvp in channelMap)
            {
                var list = kvp.Value;
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i] == null || list[j] == null) continue;
                        {
                            Handles.DrawDottedLine(list[i].transform.position, list[j].transform.position, 1f);
                            var mid = (list[i].transform.position + list[j].transform.position) / 2;
                            Handles.Label(mid, kvp.Key.ToString());
                        }
                    }
                }
            }
        }
    }
}
