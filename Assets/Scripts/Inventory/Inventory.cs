using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<InvTab> tabs;
    public Transform topLeft;
    public static Inventory Instance;
    public InvTab ActiveTab { private set; get; }

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
        ActiveTab.HideTab();
        ActiveTab = tab;
        ActiveTab.DrawTab();
    }

    private void DrawInventory()
    {
        ActiveTab.DrawTab();
    }


    private void Awake()
    {
        Instance = this;
        ActiveTab = tabs[0];
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


