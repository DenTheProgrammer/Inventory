using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        InvGroup group = GetComponent<InvGroup>();
        //Debug.Log($"Dropped {eventData.pointerDrag}");
        InvItem draggedItem;
        if (draggedItem = eventData.pointerDrag.GetComponent<InvItem>())
        {
            if (draggedItem.currentGroup != group)//if not the same group
            {
                draggedItem.currentGroup.RemoveItemFromTheGroup(draggedItem);
                group.AddItemToGroup(draggedItem);
            }
        }
    }
}
