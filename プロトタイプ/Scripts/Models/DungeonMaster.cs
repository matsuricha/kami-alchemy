// Scripts/Models/DungeonMaster.cs
using System.Collections.Generic;

namespace プロトタイプ.Scripts.Models;

// 1. まずは「箱の形」を定義（DungeonData）
public class DungeonData
{
    public string Name { get; set; }
    public int MaxSteps { get; set; }
    public string BossName { get; set; }
}

// 2. 次に「中身のリスト」を定義（DungeonMaster）
public static class DungeonMaster
{
    public static readonly List<DungeonData> AllDungeons = new List<DungeonData>
    {
        new DungeonData { Name = "ミヅハメ川", MaxSteps = 30, BossName = "ミヅハメ" },
        new DungeonData { Name = "ホオリ山", MaxSteps = 50, BossName = "ホオリ" },
        new DungeonData { Name = "ニニギの森", MaxSteps = 60, BossName = "ニニギ" },
        new DungeonData { Name = "カグツチ洞窟", MaxSteps = 100, BossName = "カグツチ" },
        new DungeonData { Name = "ツクヨミ水晶", MaxSteps = 150, BossName = "アラバキの影" },
        new DungeonData { Name = "ヨミノクニ", MaxSteps = 999, BossName = "ヌエ" }
    };
}