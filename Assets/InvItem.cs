using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InvItem : MonoBehaviour
{
    public ItemType itemType;
    public int type;
    public string title;
    public int level;
}

public enum ItemType
{
    Weapons,
    Clothing,
    Consumables
}