using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvGroupNamed : InvGroup
{
    [SerializeField]
    private string groupTitle;


    public override void LogGroup()
    {
        Debug.Log($"Group \"{groupTitle}\":");
        base.LogGroup();
    }
}
