using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Pickup
{
    public int time;

    protected override void Pick()
    {
        base.Pick();
        GameManager.Instance.PickClock(time);
        SoundManager.Instance.PlayClock();
    }
}
