using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InvItem : MonoBehaviour
{
    public string title;
    public ItemType itemType;
    public Vector2Int typeRange;
    [HideInInspector]
    public int type;
    public Vector2Int levelRange;
    [HideInInspector]
    public int level;
    [HideInInspector]
    public InvGroup currentGroup;
    [HideInInspector]
    public InvTab currentTab;

    public abstract string StatsToString();

    protected virtual void GenerateStats()
    {
        type = Random.Range(typeRange.x, typeRange.y + 1);//max exclusive
        level = Random.Range(levelRange.x, levelRange.y + 1);
    }
    public abstract ItemSaveObject CreateSaveObject();

    public virtual void LoadFromSaveObject(ItemSaveObject saveObject)
    {
        type = saveObject.type;
        level = saveObject.level;
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

    private void Awake()
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