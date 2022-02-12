using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class InvClothingItem : InvItem
{
    public Vector2Int protectionRange;
    public int protection;

    protected override void GenerateStats()
    {
        base.GenerateStats();
        protection = Random.Range(protectionRange.x, protectionRange.y + 1);
    }
    public override string StatsToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Type - {type}\nLvL - {level}\nProtection - {protection}\n");
        return stringBuilder.ToString();
    }
}
