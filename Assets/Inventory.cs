using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
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
    private void DrawInventory()
    {

    }
    // Update is called once per frame
    void Update()
    {
        DrawInventory();//!!!every frame!!!
    }
}


