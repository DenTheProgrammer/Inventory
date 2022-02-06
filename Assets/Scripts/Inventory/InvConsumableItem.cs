using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvConsumableItem : InvItem
{
    [Range(1, 100000)]
    public int seed = 777;
}
