using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class InvClothingItem : InvItem
{
    [Range(1, 100)]
    public int protection = 55;

    public override string StatsToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Type - {type}\nLvL - {level}\nProtection - {protection}\n");
        return stringBuilder.ToString();
    }
}
