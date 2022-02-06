using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvTab : MonoBehaviour
{
    public string displayName;
    public ItemType tabType; //same type as Items in it
    [SerializeField]
    private List<InvItem> ungroupedItems;
    [SerializeField]
    private List<InvGroup> groups;

    private void Awake()
    {
        gameObject.name = displayName;
        GetComponentInChildren<TextMeshProUGUI>().text = displayName;
    }

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


    public void LogTab()
    {
        Debug.Log($"Tab \"{displayName}\":");
        foreach (InvGroup group in groups)
        {
            group.LogGroup();
            
        }
        if (ungroupedItems.Count == 0) return;
        Debug.Log("Ungrouped items:");
        foreach (InvItem item in ungroupedItems)
        {
            Debug.Log(item.name);
        }
    }
}


