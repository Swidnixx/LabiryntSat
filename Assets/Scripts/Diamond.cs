using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Pickup
{
    protected override void Pick()
    {
        base.Pick();
        GameManager.Instance.PickDiamond();
        SoundManager.Instance.PlayDiamondPick();
    }
}
