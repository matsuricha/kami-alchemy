using Godot;
using System;

public partial class SceneManager : Node
{
    public void ChangeScene(string sceneName)
    {
        string path = $"res://Scenes/{sceneName}.tscn";
        GetTree().ChangeSceneToFile(path);
    }
}
