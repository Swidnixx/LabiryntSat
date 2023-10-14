using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Debug.LogError("Multiple GMs in the scene:" + gameObject.name);
        }
    }
    #endregion

    //Time
    public int time = 60;
    public bool Paused { get; private set; }

    //Pickups
    private int diamonds;
    private int goldKeys, redKeys, greenKeys;

    //Unity callbacks
    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3,  1);
    }
    private void Update()
    {
        //Pausing
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Time management
    private void Resume()
    {
        Time.timeScale = 1;
        Paused = false;
    }
    private void Pause()
    {
        Time.timeScale = 0;
        Paused = true;
    }
    void Stopper()
    {
        time--;
        if(time <= 0)
        {
            //GameOver
            CancelInvoke(nameof(Stopper));
        }
    }

    //Pickups
    public void PickDiamond()
    {
        diamonds++;
    }
    public void PickClock(int timeToAdd)
    {
        if(timeToAdd < 0 && Mathf.Abs(timeToAdd) >= time)
        {
            timeToAdd = (time - 1) * -1;
        }
        time += timeToAdd;
    }
    public void FreezeTime(int time)
    {
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), time, 1);
    }
    public void PickKey(KeyColor color)
    {
        switch (color)
        {
            case KeyColor.Gold:
                goldKeys++;
                break;
            case KeyColor.Red:
                redKeys++;
                break;
            case KeyColor.Green:
                greenKeys++;
                break;
        }
    }
}
