using Godot;
using System;
using System.Threading.Tasks;
using プロトタイプ.Scripts.Models;
using プロトタイプ.Scripts.Interfaces; // インターフェースをインポート
using プロトタイプ.Scripts.Systems.DungeonEvents; // イベント群をインポート
namespace プロトタイプ.Scripts.Nodes.Dungeon;

public partial class DungeonManager : Node
{
    [Export] public Label FloorLabel; // 階層表示用
    [Export] public Label LogLabel;   // メッセージ用

    private DungeonData _data;
    private int _currentStep = 1;

    public override void _Ready()
    {
        // GameStateにセットされた「今から潜るダンジョン」を取得
        _data = GameState.Instance.CurrentDungeon;

        if (_data == null) _data = DungeonMaster.AllDungeons[0];
            UpdateUI();
    }

public async Task UpdateFloor(int delta)
    {
        _currentStep = Math.Clamp(_currentStep + delta, 1, _data.MaxSteps);
        UpdateUI();

        // 最深部判定を優先
        if (_currentStep == _data.MaxSteps)
        {
            LogLabel.Text = $"最深部だ！{_data.BossName}が現れた！";
            FinishDungeon();
            return;
        }

        // 移動メッセージ
        LogLabel.Text = delta > 0 ? "足を進めた..." : "少し戻った...";
        
        // 少し待ってからイベント発生（RSっぽさを出すならここを調整）
        await ResolveRandomEvent();
    }
    private async Task ResolveRandomEvent()
    {
        float roll = (float)GD.RandRange(0.0, 1.0);
        IDungeonEvent selectedEvent;

        // 指定された比率で抽選
        if (roll < 0.60f)      selectedEvent = new NothingEvent();
        else if (roll < 0.80f) selectedEvent = new NothingEvent(); // 敵は一旦Nothingで代用
        else if (roll < 0.95f) selectedEvent = new ItemEvent();
        else                   selectedEvent = new NothingEvent(); // 特殊イベントも一旦Nothing

        await selectedEvent.Execute(this);
    }
    private async void FinishDungeon()
    {
        // 1. メッセージを出す
        LogLabel.Text = $"{_data.BossName}に勝利した！";
        
        // 2. 踏破回数をカウントアップ（GameStateに保存）
        GameState.Instance.AddClearCount(_data.Name);

        // 3. 少し待機（余韻を持たせる）
        await ToSignal(GetTree().CreateTimer(2.0f), "timeout");

        // 4. マップシーンへ戻る
        var sceneManager = GetNode<SceneManager>("/root/SceneManager");
        sceneManager.ChangeScene("Map");
    }
    private void UpdateUI()
    {
        FloorLabel.Text = $"{_data.Name} {_currentStep} / {_data.MaxSteps}";
    }
}