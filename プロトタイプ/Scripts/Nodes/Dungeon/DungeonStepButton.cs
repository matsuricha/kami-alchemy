using Godot;
using System;

namespace プロトタイプ.Scripts.Nodes.Dungeon;
public partial class DungeonStepButton : Button
{
    // 進むなら 1、戻るなら -1 をエディタで入力
    [Export] public int StepDelta = 1; 

    public override void _Ready()
    {
        Pressed += () => {
            var manager = GetTree().CurrentScene as DungeonManager; 
            manager?.UpdateFloor(StepDelta);
        };
    }
}
