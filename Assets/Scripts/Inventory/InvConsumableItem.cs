using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class InvConsumableItem : InvItem
{
    [Range(1, 100000)]
    public int seed = 777;

    public override string StatsToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Type - {type}\nLvL - {level}\nSeed - {seed}");
        return stringBuilder.ToString();
    }
}
