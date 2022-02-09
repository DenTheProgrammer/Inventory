using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private InvItem item;


    private void Awake()
    {
        item = GetComponent<InvItem>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Instance.Show(item.title, item.StatsToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Instance.Hide();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TooltipSystem.Instance.Hide();
    }
}
