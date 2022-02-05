using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<InvTab> tabs;
    [SerializeField]
    public InvTab activeTab { private set; get; }

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
        activeTab = tabs[0];
    }
    // Update is called once per frame
    void Update()
    {
        DrawInventory();//!!!every frame!!!
    }
}


