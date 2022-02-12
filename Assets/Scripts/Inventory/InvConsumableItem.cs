using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class InvConsumableItem : InvItem
{
    public Vector2Int seedRange;
    public int seed;
    protected override void GenerateStats()
    {
        base.GenerateStats();
        seed = Random.Range(seedRange.x, seedRange.y + 1);
    }

    public override string StatsToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Type - {type}\nLvL - {level}\nSeed - {seed}");
        return stringBuilder.ToString();
    }

    public override ItemSaveObject CreateSaveObject()
    {
        return new ConsumableItemSaveObject(title, type, level, seed);
    }
    public override void LoadFromSaveObject(ItemSaveObject saveObject)
    {
        base.LoadFromSaveObject(saveObject);
        ConsumableItemSaveObject consumableItemSaveObject = (ConsumableItemSaveObject)saveObject;
        seed = consumableItemSaveObject.seed;
    }
}

[System.Serializable]
public class ConsumableItemSaveObject : ItemSaveObject
{
    public int seed;
    public ConsumableItemSaveObject(string itemTitle, int type, int level, int seed) : base(itemTitle, type, level)
    {
        this.seed = seed;
    }
}