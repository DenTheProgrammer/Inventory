using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InvGroup : MonoBehaviour
{
    public List<InvItem> items;

    private void Awake()
    {
        items = new List<InvItem>();
    }
    public void AddItemToGroup(InvItem item)
    {
        //GameObject newItemGO = Instantiate(item.gameObject, transform);
        items.Add(item);
        item.transform.position = transform.position;
        item.transform.SetParent(gameObject.transform);
        item.currentGroup = this;
        Inventory.Instance.DrawInventory();
    }

    public void RemoveItemFromTheGroup(InvItem item)
    {
        items.Remove(item);
        Inventory.Instance.DrawInventory();
    }


    public void DestroyItemsInGroup()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].DestroyItem();
        }
        items = new List<InvItem>();
    }

    public virtual Vector2 DrawGroup(Vector2 nextGroupSlot)
    {
        Vector2 spacing = Inventory.Instance.spacingSize;
        Vector2 itemSize = Inventory.Instance.slotSize;
        int itemsInRow = Inventory.Instance.cellsInRow;
        int rows = Mathf.CeilToInt((float)items.Count / itemsInRow);
        float groupWidth = Inventory.Instance.gameObject.GetComponent<RectTransform>().rect.width - (2* spacing.y);
        float groupHeight = (itemSize.y * rows) + (spacing.y * (rows + 1));
        if (groupHeight < itemSize.y) groupHeight = itemSize.y;////empty group
        //Draw Group
        RectTransform groupRectTransform = gameObject.GetComponent<RectTransform>();
        groupRectTransform.sizeDelta = new Vector2(groupWidth, groupHeight);
        groupRectTransform.position = nextGroupSlot + new Vector2(groupWidth/2 + spacing.x,-groupHeight/2 -spacing.y);
        //
        //Draw Group Items

        
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
