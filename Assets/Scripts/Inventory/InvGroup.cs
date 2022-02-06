using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InvGroup : MonoBehaviour
{
    [SerializeField]
    public List<InvItem> items;

    public void AddItemToGroup(InvItem item)
    {
        if (items == null)
            items = new List<InvItem>();
        items.Add(item);
        GameObject newItem = Instantiate(item.gameObject, Inventory.Instance.topLeft);
        newItem.gameObject.transform.SetParent(gameObject.transform);
    }

    public void RemoveItemFromTheGroup(InvItem item)
    {
        if (items != null)
        {
            items.Remove(item);
            Destroy(item.gameObject);
        }
    }

    public virtual void DrawGroup()
    {
        //TODO
    }

    public virtual void LogGroup()
    {
        foreach(InvItem item in items)
        {
            Debug.Log(item.name);
        }
    }
}
