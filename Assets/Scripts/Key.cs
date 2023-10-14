using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Pickup
{
    public KeyColor color;

    protected override void Pick()
    {
        base.Pick();
        GameManager.Instance.PickKey(color);
    }
}

public enum KeyColor { Gold, Red, Green }

