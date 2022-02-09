using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem Instance;
    public Tooltip tooltip;

    private void Awake()
    {
        Instance = this;
    }

    public void Show(string header, string content)
    {
        tooltip.SetText(header, content);
        tooltip.gameObject.SetActive(true);
    }

    public void Hide()
    {
        tooltip.gameObject.SetActive(false);
    }

    
}
