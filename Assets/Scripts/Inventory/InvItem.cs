using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InvItem : MonoBehaviour
{
    public ItemType itemType;
    public Vector2Int typeRange;
    public int type;
    public string title;
    public Vector2Int levelRange;
    public int level;
    public InvGroup currentGroup;
    public InvTab currentTab;

    public abstract string StatsToString();

    protected virtual void GenerateStats()
    {
        type = Random.Range(typeRange.x, typeRange.y + 1);//max exclusive
        level = Random.Range(levelRange.x, levelRange.y + 1);
    }

    public void MoveToAnotherGroup(InvGroup anotherGroup)
    {
        if (anotherGroup != currentGroup)
        {
            currentGroup.RemoveItemFromTheGroup(this);
            anotherGroup.AddItemToGroup(this);
        }
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        gameObject.name = title;
        GenerateStats();
    }

}


public enum ItemType
{
    Weapons,
    Clothing,
    Consumables
}