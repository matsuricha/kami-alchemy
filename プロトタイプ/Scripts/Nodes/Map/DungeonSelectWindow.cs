using Godot;
using System;
using プロトタイプ.Scripts.Models; // DungeonDataやGameStateを参照

namespace プロトタイプ.Scripts.Nodes.Map;

public partial class DungeonSelectWindow : PanelContainer
{
    [Export] public Label TitleLabel;
    [Export] public Label InfoLabel;

    private DungeonData _selectedDungeon;

    public override void _Ready()
    {
        // 最初は非表示にしておく
        this.Visible = false;
    }

    // マップ上の各地点ボタンから呼ばれる
    public void Open(DungeonData data)
    {
        _selectedDungeon = data;
        TitleLabel.Text = data.Name;

        // GameStateから情報を取得
        var state = GameState.Instance;
        int clearCount = state.DungeonClearCounts.ContainsKey(data.Name) 
            ? state.DungeonClearCounts[data.Name] : 0;
            
        InfoLabel.Text = $"踏破回数: {clearCount}回";
        
        this.Visible = true;
    }

    // 「潜る」ボタン（EnterButton）にシグナルで接続
    private void OnEnterButtonPressed()
    {
        // 現在選んでいるダンジョンをGameStateに保持させてから遷移
        GameState.Instance.CurrentDungeon = _selectedDungeon;

        var sceneManager = GetNode<SceneManager>("/root/SceneManager");
        sceneManager.ChangeScene("Dungeon");
    }

    // 「閉じる」ボタン（CloseButton）にシグナルで接続
    private void OnCloseButtonPressed()
    {
        this.Visible = false;
    }
}