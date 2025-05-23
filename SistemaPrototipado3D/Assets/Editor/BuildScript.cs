using UnityEditor;

public class BuildScript
{
    public static void BuildGame()
    {
        string[] scenes = { "Assets/Scenes/PlayDemo.unity" };
        BuildPipeline.BuildPlayer(scenes, "Builds/Windows/MyGame.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
    }
}
