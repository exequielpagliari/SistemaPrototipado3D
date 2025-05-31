using UnityEditor;
using UnityEditorInternal;


public static class ManagerEditorPrefs
{
    public static bool debug;
    public static void Save()
    {
        
        EditorPrefs.SetBool("Prototipe.Debug", true);
       
    }

    public static void Load()
    {
        
        bool debug = EditorPrefs.GetBool("Prototipe.Debug", false);

        UnityEngine.Debug.Log($"Debug: {debug}");
    }

    public static bool GetDebug()
    {
        return debug;
    }

    public static void SetDebug(bool value)
    {
        debug = value;
    }
}