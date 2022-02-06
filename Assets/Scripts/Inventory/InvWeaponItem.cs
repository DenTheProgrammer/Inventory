using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvWeaponItem : InvItem
{
    public bool equipped;
    [Range(1, 100)]
    public int damage;

    private void Awake()
    {
        itemType = ItemType.Weapons;
    }
}
