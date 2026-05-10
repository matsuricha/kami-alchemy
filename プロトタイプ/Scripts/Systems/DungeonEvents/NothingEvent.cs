using System.Threading.Tasks;
using プロトタイプ.Scripts.Interfaces;
using プロトタイプ.Scripts.Nodes.Dungeon;

namespace プロトタイプ.Scripts.Systems.DungeonEvents;

public class NothingEvent : IDungeonEvent
{
    public async Task Execute(DungeonManager manager)
    {
        manager.LogLabel.Text = "静寂が包んでいる...";
        await Task.CompletedTask; // 非同期処理がない場合のダミー
    }
}