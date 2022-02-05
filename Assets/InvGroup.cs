using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvGroup : MonoBehaviour
{
    [SerializeField]
    private List<InvItem> items;
    [SerializeField]
    private string groupTitle;

    public void AddItemToGroup(InvItem item)
    {
        if (items == null)
            items = new List<InvItem>();
        items.Add(item);
    }

    public void RemoveItemFromTheGroup(InvItem item)
    {
        if (items != null)
            items.Remove(item);
    }
}
