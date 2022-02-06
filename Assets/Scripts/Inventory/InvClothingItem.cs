using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvClothingItem : InvItem
{
    [Range(1, 100)]
    public int protection;

    private void Awake()
    {
        itemType = ItemType.Consumables;
    }
}
