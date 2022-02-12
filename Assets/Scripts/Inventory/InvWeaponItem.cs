using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class InvWeaponItem : InvItem
{
    public bool equipped;
    public Vector2Int damageRange;
    public int damage;

    protected override void GenerateStats()
    {
        base.GenerateStats();
        damage = Random.Range(damageRange.x, damageRange.y + 1);
        equipped = Random.value < 0.5;//       50/50 starting equip chance - stupid but ok
    }
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
