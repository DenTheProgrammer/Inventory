using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvGroupNamed : InvGroup
{
    [SerializeField]
    public string groupTitle;

    public override Vector2 DrawGroup(Vector2 nextGroupSlot)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = this.groupTitle;
        return base.DrawGroup(nextGroupSlot);
    }

    public override void LogGroup()
    {
        Debug.Log($"Group \"{groupTitle}\":");
        base.LogGroup();
    }
}
