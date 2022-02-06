using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InvItem : MonoBehaviour
{
    public ItemType itemType;
    [Range(1,5)]
    public int type = 1;
    public string title;
    [Range(1,7)]
    public int level = 1;

    

    private void Start()
    {
        gameObject.name = title;
    }
}


public enum ItemType
{
    Weapons,
    Clothing,
    Consumables
}