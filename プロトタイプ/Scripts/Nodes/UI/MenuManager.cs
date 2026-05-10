using Godot;
using System;
using プロトタイプ.Scripts.Nodes.UI; // InventoryWindowなどが含まれる名前空間

namespace プロトタイプ.Scripts.Nodes.UI;

public partial class MenuManager : Control
{
    // 右側の表示エリア
    [Export] public Control RightPanel;

    // 各タブのシーン（tscn）をエディタからアタッチ
    [Export] public PackedScene ItemsScene;
    [Export] public PackedScene EquipmentScene;
    [Export] public PackedScene SkillTreeScene;
    [Export] public PackedScene LibraryScene;
    [Export] public PackedScene SaveLoadScene;
    [Export] public PackedScene SettingsScene;

    // --- 各ボタンのシグナルに接続するメソッド ---

    public void OnItemsButtonPressed() => SwitchTab(ItemsScene);

    public void OnEquipmentButtonPressed() => SwitchTab(EquipmentScene);

    public void OnSkillTreeButtonPressed() => SwitchTab(SkillTreeScene);

    public void OnLibraryButtonPressed() => SwitchTab(LibraryScene);

    public void OnSaveLoadButtonPressed() => SwitchTab(SaveLoadScene);

    public void OnSettingsButtonPressed() => SwitchTab(SettingsScene);

    public void OnExitToTitleButtonPressed()
    {
        // タイトルへ戻る処理（SceneManager経由）
        var sceneManager = GetNode<SceneManager>("/root/SceneManager");
        sceneManager.ChangeScene("Title"); // タイトルシーン名は適宜変更してください
    }

    // --- タブ切り替えのコアロジック ---
    private void SwitchTab(PackedScene nextScene)
    {
        if (nextScene == null)
        {
            GD.PrintErr("タブシーンがアタッチされていません。");
            return;
        }

        // 1. 右側パネルをクリーンアップ
        foreach (Node child in RightPanel.GetChildren())
        {
            child.QueueFree();
        }

        // 2. 新しいシーンをインスタンス化
        var instance = nextScene.Instantiate();
        RightPanel.AddChild(instance);

        // 3. インベントリの場合はリストを更新（既存のロジック流用）
        if (instance is InventoryWindow inv)
        {
            inv.RefreshList();
        }
    }
}