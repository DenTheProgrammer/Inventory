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
    [SerializeField]
    private List<InvTab> tabs;

    public void AddItemToTheInventory(GameObject itemPrefab)
    {
        GameObject newItemGO = Instantiate(itemPrefab);
        InvItem newItem = newItemGO.GetComponent<InvItem>();
        foreach (InvTab tab in tabs)
        {
            if (tab.tabType == newItem.itemType)
            {
                tab.AddItemToTheTab(newItem);
                newItem.currentTab = tab;
                return;
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
        LogInventory();
    }


    private void Awake()
    {
        Instance = this;
        activeTab = tabs[0];
    }
    // Update is called once per frame
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


