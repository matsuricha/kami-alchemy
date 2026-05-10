using System.Threading.Tasks;
using Godot;
using プロトタイプ.Scripts.Interfaces;
using プロトタイプ.Scripts.Nodes.Dungeon;
using プロトタイプ.Scripts.Models;
using System.Linq;

namespace プロトタイプ.Scripts.Systems.DungeonEvents;

public class ItemEvent : IDungeonEvent
{
    public async Task Execute(DungeonManager manager)
    {
        // 1. 合成結果(ID 5以上)を除いた「素材アイテム」からランダムに抽選
        var materialItems = ItemMaster.AllItems.Where(i => i.Id < 5).ToList();

        // 2. 乱数でインデックスを決定
        // GD.RandRange(min, max) は double を返すので、(int) でキャストします
        int randomIndex = (int)GD.RandRange(0, materialItems.Count); 
        var pickedItem = materialItems[randomIndex];

        // 3. GameStateのインベントリに追加
        GameState.Instance.AddItem(pickedItem.Id, 1);

        // 4. アンディーメンテ風のログ表示
        manager.LogLabel.Text = $"足元に何かが落ちている...\n[ {pickedItem.Name} ] を手に入れた！";
        // 追記：説明文も流すとよりジスさん作品っぽくなります
        // manager.LogLabel.Text += $"\n({pickedItem.Description})";
        
        await Task.CompletedTask;
    }
}