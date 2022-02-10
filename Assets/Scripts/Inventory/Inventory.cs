using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public Transform topLeft;
    public static Inventory Instance;
    public InvTab activeTab;
    public Vector2 slotSize;
    public Vector2 spacingSize;
    public int cellsInRow;
    public List<InvTab> tabs;

    private void Awake()
    {
        Instance = this;
        activeTab = tabs[0];
    }

    public InvItem AddItemToTheInventory(GameObject itemPrefab)
    {
        GameObject newItemGO = Instantiate(itemPrefab);
        InvItem newItem = newItemGO.GetComponent<InvItem>();
        foreach (InvTab tab in tabs)
        {
            if (tab.tabType == newItem.itemType)
            {
                tab.AddItemToTheTab(newItem);
                return newItem;
            }
        }
        throw new NotImplementedException($"Unknown Item type - {newItem.type}");
    }


    public void DestroyAllItems()
    {
        foreach (InvTab tab in tabs)
        {
            tab.DestroyItemsInTab();
        }
        DrawInventory();
    }
    public void ChangeActiveTab(InvTab tab)
    {
        activeTab.HideTab();
        activeTab = tab;
        activeTab.DrawTab();
        DrawInventory();
    }

    public void DrawInventory()
    {
        Debug.LogWarning("Drawing Inventory");
        activeTab.DrawTab();
        //LogInventory();
    }


    void Update()
    {
        ///////////////DrawInventory();//////////////for tests only
    }



    public void LogInventory()
    {
        Debug.Log("Inventory:");
        foreach (InvTab tab in tabs)
        {
            tab.LogTab();
        }
    }
}

[Serializable]
public class InventorySaveObject
{
    public List<ItemSaveObject> items;

    public InventorySaveObject()
    {
        items = new List<ItemSaveObject>();
    }
}

[Serializable]
public class ItemSaveObject
{
    public string itemTitle;
    public string groupName;

    public ItemSaveObject(string itemTitle, string groupName = null)
    {
        this.itemTitle = itemTitle;
        this.groupName = groupName;
    }
}

