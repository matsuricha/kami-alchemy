
using Godot;
using System.Collections.Generic;

namespace プロトタイプ.Scripts.Models;

public partial class GameState : Node 
{
    // シングルトンとしてどこからでもアクセス可能にする（おまじない）
    public static GameState Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }

    // --- グローバル変数（ステータス） ------------------------------------------------------------------
    public int Shinryoku { get; set; } = 100;
    public int Ninki { get; set; } = 0;
    public int Gold { get; set; } = 0;
    public int Debt { get; set; } = 1000000;

    // --- ダンジョン進行状況 ----------------------------------------------------------------------------
    // Key: ダンジョン名, Value: 踏破回数
    public Dictionary<string, int> DungeonClearCounts { get; set; } = new Dictionary<string, int>();
    public DungeonData CurrentDungeon { get; set; } 

    // 踏破回数を増やす
    public void AddClearCount(string dungeonName)
    {
        if (!DungeonClearCounts.ContainsKey(dungeonName))
        {
            DungeonClearCounts[dungeonName] = 0;
        }
        DungeonClearCounts[dungeonName]++;
    }
    // --- アイテム管理 ----------------------------------------------------------------------------
    // インベントリの実体： Key=ItemId, Value=個数
    public Dictionary<int, int> Inventory { get; private set; } = new Dictionary<int, int>();
    // アイテムを追加
    public void AddItem(int itemId, int count = 1)
    {
        if (Inventory.ContainsKey(itemId))
        {
            Inventory[itemId] += count;
        }
        else
        {
            Inventory[itemId] = count;
        }       
        // SE的デバッグログ
        GD.Print($"アイテム獲得: {ItemMaster.AllItems.Find(i => i.Id == itemId)?.Name} (+{count}) / 現在: {Inventory[itemId]}個");
    }
}
// using Godot;
// using System.Collections.Generic;

// namespace プロトタイプ.Scripts.Models;
// // AutoloadにするならNodeを継承しておくと便利です
// public partial class GameState : Node 
// {
    
// // グローバル変数
//     public int Shinryoku { get; set; } = 100; // 神力
//     public int Ninki { get; set; } = 0;     // 人気
//     public int Gold { get; set; } = 0;      // 現金
//     public int Debt { get; set; } = 1000000; // 借金（例：100万）
    
//     public int CurrentStep { get; set; } = 0;   // 今何歩目？    
//     // 状態をリセットするメソッド（ボスを倒した後とか用）
//     public void ResetDungeon()
//     {
//         CurrentStep = 0;
//     }
//     // 現在どのダンジョンにいるかの「インデックス（番号）」だけ持つ
//     public int CurrentDungeonIndex { get; set; } = 0;

//     // ヘルパープロパティ：今のダンジョン情報をマスターから引っ張ってくる
//     public DungeonData CurrentDungeon => DungeonMaster.AllDungeons[CurrentDungeonIndex];
//     // 所持品データ：Dictionary<アイテムID, 所持数>
//     public Dictionary<int, int> Inventory { get; set; } = new Dictionary<int, int>();
//         // アイテムを手に入れるメソッド
//     public void AddItem(int itemId, int count = 1)
//     {
//         if (Inventory.ContainsKey(itemId))
//             Inventory[itemId] += count;
//         else
//             Inventory[itemId] = count;
//     }
//     public int? CombineItems(int id1, int id2)
//     {
//         // 材料の順番が逆でもOKなように判定
//         var recipe = RecipeMaster.AllRecipes.Find(r => 
//             (r.MaterialId1 == id1 && r.MaterialId2 == id2) || 
//             (r.MaterialId1 == id2 && r.MaterialId2 == id1)
//         );

//         if (recipe != null)
//         {
//             // 材料を1つずつ減らす
//             AddItem(id1, -1);
//             AddItem(id2, -1);
//             // 完成品を追加
//             AddItem(recipe.ResultId, 1);
//             return recipe.ResultId;
//         }

//         return null; // レシピがなければnull（失敗）
        
//     }
//     public Dictionary<int, int> RecipeProficiency { get; set; } = new Dictionary<int, int>();

//     public void IncreaseProficiency(int recipeId)
//     {
//         if (RecipeProficiency.ContainsKey(recipeId))
//             RecipeProficiency[recipeId]++;
//         else
//             RecipeProficiency[recipeId] = 1;
//     }
//     // GameState.cs に追加
//     public void ChangeScene(string sceneName)
//     {
//         // res://Scenes/HomeBase.tscn のようなパスを組み立てる
//         string path = $"res://Scenes/{sceneName}.tscn";
//         GetTree().ChangeSceneToFile(path);
//     }
// }
// public class PlayerStatus 
// {
//     public string Name { get; set; } = "神様";
//     public int Level { get; set; } = 1;
//     public int Hp { get; set; } = 100;
//     public int MaxHp { get; set; } = 100;
//     public int Attack { get; set; } = 10;

// }
