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

    public void AddItemToTheInventory(InvItem item)
    {
        foreach (InvTab tab in tabs)
        {
            if (tab.tabType == item.itemType)
            {
                tab.AddItemToTheTab(item);
                return;
            }
        }
        throw new NotImplementedException($"Unknown Item type - {item.type}");
    }

    public void ClearInventory()
    {
        foreach (InvTab tab in tabs)
        {
            tab.ClearTab();
        }
    }

    public void ChangeActiveTab(InvTab tab)
    {
        activeTab.HideTab();
        activeTab = tab;
        activeTab.DrawTab();
    }

    private void DrawInventory()
    {
        activeTab.DrawTab();
    }


    private void Awake()
    {
        Instance = this;
        activeTab = tabs[0];
    }
    // Update is called once per frame
    void Update()
    {
        DrawInventory();//!!!every frame!!!
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


