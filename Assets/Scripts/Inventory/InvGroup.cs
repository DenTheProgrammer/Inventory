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
        GameObject newItem = Instantiate(item.gameObject, transform);
        items.Add(newItem.GetComponent<InvItem>());
        newItem.transform.SetParent(gameObject.transform);
        Inventory.Instance.DrawInventory();
    }

    public void RemoveItemFromTheGroup(InvItem item)
    {
        if (items != null)
        {
            items.Remove(item);
            Destroy(item.gameObject);
        }
        Inventory.Instance.DrawInventory();
    }

    public virtual Vector2 DrawGroup(Vector2 nextGroupSlot)
    {
        Vector2 spacing = Inventory.Instance.spacingSize;
        int rows = Mathf.CeilToInt((float)items.Count / Inventory.Instance.cellsInRow);
        float groupWidth = Inventory.Instance.gameObject.GetComponent<RectTransform>().rect.width - (2* spacing.y);
        float groupHeight = (Inventory.Instance.slotSize.y * rows) + (spacing.y * (rows + 1));
        //Draw Group
        RectTransform groupRectTransform = gameObject.GetComponent<RectTransform>();
        groupRectTransform.sizeDelta = new Vector2(groupWidth, groupHeight);
        groupRectTransform.position = nextGroupSlot + new Vector2(groupWidth/2 + spacing.x,-groupHeight/2 -spacing.y);
        //
        //Draw Group Items
        int itemsInRow = Inventory.Instance.cellsInRow;
        Vector2 itemSize = Inventory.Instance.slotSize;
        
        for (int i = 0; i < items.Count; i++)
        {
            RectTransform itemRectTransform = items[i].GetComponent<RectTransform>();
            itemRectTransform.anchoredPosition = new Vector2(itemSize.x/2 + spacing.x, -(itemSize.y/2 + spacing.y));
            itemRectTransform.anchoredPosition += new Vector2((i % itemsInRow) * (itemSize.x + spacing.x), -i / itemsInRow * (itemSize.y + spacing.y));
        }
        //
        nextGroupSlot.y -= (groupHeight + spacing.y);
        return nextGroupSlot;
    }

    public virtual void LogGroup()
    {
        foreach(InvItem item in items)
        {
            Debug.Log(item.name);
        }
    }
}
