using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class InvWeaponItem : InvItem
{
    public bool equipped;
    [Range(1, 100)]
    public int damage = 25;

    public override string StatsToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Type - {type}\nLvL - {level}\nDamage - {damage}\n");
        if (equipped)
            stringBuilder.Append("<color=green>Equipped</color>");
        else
            stringBuilder.Append("<color=red>Not equipped</color>");
        return stringBuilder.ToString();
    }
}
