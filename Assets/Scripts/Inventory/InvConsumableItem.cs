using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class InvConsumableItem : InvItem
{
    public Vector2Int seedRange;
    public int seed;
    protected override void GenerateStats()
    {
        base.GenerateStats();
        seed = Random.Range(seedRange.x, seedRange.y + 1);
    }

    public override string StatsToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Type - {type}\nLvL - {level}\nSeed - {seed}");
        return stringBuilder.ToString();
    }
}
