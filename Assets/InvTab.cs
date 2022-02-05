using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvTab : MonoBehaviour
{
    public ItemType tabType; //same type as Items in it
    [SerializeField]
    private List<InvItem> ungroupedItems;
    [SerializeField]
    private List<InvGroup> groups;

    public void AddItemToTheTab(InvItem item)
    {
        if (ungroupedItems == null)
            ungroupedItems = new List<InvItem>();
        ungroupedItems.Add(item);
    }

    public void RemoveItemFromTheTab(InvItem item)
    {
        foreach (InvGroup group in groups)
        {
            group.RemoveItemFromTheGroup(item);
        }
        ungroupedItems.Remove(item);
    }

    public void HideTab()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }

    public void DrawTab()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(true);
    }

    public void ClearTab()
    {
        ungroupedItems = null;
        groups = null;
    }
}


