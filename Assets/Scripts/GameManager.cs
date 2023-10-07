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

    public int time = 60;
    public bool Paused { get; private set; }

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
}
