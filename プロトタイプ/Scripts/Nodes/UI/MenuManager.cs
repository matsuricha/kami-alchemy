using Godot;
using System;

namespace プロトタイプ.Scripts.Nodes.UI;

public partial class MenuManager : Control
{
    [Export] public Control RightPanel;

    [Export] public PackedScene ItemsScene;
    [Export] public PackedScene EquipmentScene;
    [Export] public PackedScene SkillTreeScene;
    [Export] public PackedScene LibraryScene;
    [Export] public PackedScene SaveLoadScene;
    [Export] public PackedScene SettingsScene;

    public override void _Ready()
    {
        // パスをエディタの構造（CanvasLayer/HBoxContainer/VBoxContainer/ItemsButton）に合わせます
        var itemsButton = GetNode<Button>("CanvasLayer/HBoxContainer/VBoxContainer/ItemsButton");
        
        if (itemsButton != null)
        {
            // ⚠️ エラーの原因だった「-=」を削除し、安全に1回だけ登録する形にします
            itemsButton.Pressed += OnItemsButtonPressed;
            GD.Print("【システム】ItemsButtonのプログラム接続に成功！");
        }
        else
        {
            GD.PrintErr("【エラー】ItemsButtonが見つかりません。ツリーの階層を確認してください。");
        }
    }

    public void OnItemsButtonPressed()
    {
        GD.Print("【デバッグ】道具ボタンが押されました。切り替えを開始します。");
        SwitchTab(ItemsScene);
    }

    private void SwitchTab(PackedScene nextScene)
{
    if (RightPanel == null)
    {
        GD.PrintErr("【エラー】RightPanelがインスペクターで設定されていません！");
        return;
    }

    if (nextScene == null)
    {
        GD.PrintErr("【エラー】ItemsScene（設計図）がアタッチされていません。");
        return;
    }

    // 1. 右側パネルの古い中身を全消去
    foreach (Node child in RightPanel.GetChildren())
    {
        child.QueueFree();
    }

    // 2. 最も汎用的な「Node」型として実体化させることで、エラーを100%回避します！
    Node instance = nextScene.Instantiate();
    RightPanel.AddChild(instance);
    GD.Print($"【システム】右側パネルに {instance.Name} を安全に展開しました。");

    // 3. インベントリ画面（InventoryWindow）ならリストを更新
    // ⚠️「inv」という変数に型を変換して中の RefreshList を呼び出します
    if (instance is InventoryWindow inv)
    {
        GD.Print("【システム】インベントリのアイテムリストを更新します...");
        inv.RefreshList();
    }
}
}