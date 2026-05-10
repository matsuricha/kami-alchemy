using System.Threading.Tasks;
using プロトタイプ.Scripts.Nodes;

namespace プロトタイプ.Scripts.Interfaces;

public interface IDungeonEvent
{
    // 各イベントが実行する具体的な処理
    Task Execute(Nodes.Dungeon.DungeonManager manager);
}