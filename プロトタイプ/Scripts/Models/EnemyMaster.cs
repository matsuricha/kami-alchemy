namespace プロトタイプ.Scripts.Models;
using System.Collections.Generic;

public class EnemyData
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Attack { get; set; }
    public int Exp { get; set; }
    public long Gold { get; set; }
}

public static class EnemyMaster
{
    public static readonly List<EnemyData> AllEnemies = new List<EnemyData>
    {
        new EnemyData { Name = "川のザコ魚", Hp = 20, Attack = 5, Exp = 10, Gold = 15 },
        new EnemyData { Name = "怒れるカッパ", Hp = 50, Attack = 12, Exp = 30, Gold = 100 }
    };
}