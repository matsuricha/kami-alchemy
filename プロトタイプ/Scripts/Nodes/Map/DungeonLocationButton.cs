using Godot;
using プロトタイプ.Scripts.Models;

namespace プロトタイプ.Scripts.Nodes.Map;

public partial class DungeonLocationButton : Button
{
    [Export] public int DungeonIndex; 
    
    // これを追加！インスペクターからDungeonSelectWindowを登録できるようにします
    [Export] public DungeonSelectWindow TargetWindow; 

    public override void _Ready()
    {
        // 1. マスターデータから名前を取得してテキストに反映
        if (DungeonMaster.AllDungeons.Count > DungeonIndex)
        {
            this.Text = DungeonMaster.AllDungeons[DungeonIndex].Name;
        }

        // 2. クリック処理
        Pressed += () => 
        {
            if (TargetWindow != null)
            {
                var data = DungeonMaster.AllDungeons[DungeonIndex];
                TargetWindow.Open(data); // 直接参照して開く
            }
            else
            {
                GD.PrintErr($"{this.Name}: TargetWindowがセットされていません！");
            }
        };
    }
}