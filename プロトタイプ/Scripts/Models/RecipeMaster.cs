// Scripts/Models/RecipeMaster.cs
using System.Collections.Generic;

namespace プロトタイプ.Scripts.Models;

public class RecipeData
{
    public int MaterialId1 { get; set; }
    public int MaterialId2 { get; set; }
    public int ResultId { get; set; }
    // 必要なら「成功率」や「必要レベル」もここに追加！
}

public static class RecipeMaster
{
    public static readonly List<RecipeData> AllRecipes = new List<RecipeData>
    {
        // 基本レシピ
        new RecipeData { MaterialId1 = 0, MaterialId2 = 1, ResultId = 5 }, // 味噌おにぎり
        new RecipeData { MaterialId1 = 2, MaterialId2 = 3, ResultId = 6 }, // 魚のムニエル
        
        // 予定している30〜50個のレシピをここにガシガシ追加していく
        // new RecipeData { ... },
        // new RecipeData { ... },
    };
}