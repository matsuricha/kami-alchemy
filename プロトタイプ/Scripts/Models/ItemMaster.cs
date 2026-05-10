// Scripts/Models/ItemMaster.cs
using System.Collections.Generic;

namespace プロトタイプ.Scripts.Models;

public class ItemData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } // 合成のヒントとか書くとアンディーメンテ風！
}

public static class ItemMaster
{
    public static readonly List<ItemData> AllItems = new List<ItemData>
    {
        new ItemData { Id = 0, Name = "米", Description = "全ての基本。" },
        new ItemData { Id = 1, Name = "味噌", Description = "香ばしい発酵調味料。" },
        new ItemData { Id = 2, Name = "魚", Description = "ミヅハメ川で獲れた新鮮な魚。" },
        new ItemData { Id = 3, Name = "小麦粉", Description = "さらさらした粉。" },
        // 5番以降を合成結果アイテムにすると管理しやすいです
        new ItemData { Id = 5, Name = "即席・味噌おにぎり", Description = "米と味噌を合わせた携帯食。" },
        new ItemData { Id = 6, Name = "魚のムニエル", Description = "魚と小麦粉を焼いたもの。" }
    };
}