using Godot;
namespace プロトタイプ.Scripts.Models;
public partial class SceneTransitionButton : Button
{
    [Export]
    public string TargetSceneName { get; set; } = "";

    public override void _Ready()
    {
        // ボタン自身が押された時のイベントを自分自身に接続する
        Pressed += OnPressed;
    }

    private void OnPressed()
    {
        if (string.IsNullOrEmpty(TargetSceneName)) return;

        // SceneManagerの移動メソッドを呼び出す
        var sceneManager = GetNode<SceneManager>("/root/SceneManager");
        sceneManager.ChangeScene(TargetSceneName);
    }
}