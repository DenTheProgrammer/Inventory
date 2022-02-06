using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvGroupDefault : InvGroup
{
    public override void LogGroup()
    {
        Debug.Log($"Ungrouped Items:");
        base.LogGroup();
    }
}
