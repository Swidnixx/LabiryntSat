using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    bool gameOver;

    //UI Display
    public Text diamondsText, timeText, redKeysText, greenKeysText, goldKeysText;
    public Image freezeImage;
    public GameObject pausePanel, losePanel, winPanel;

    //Pickups
    private int diamonds;
    private int goldKeys, redKeys, greenKeys;

    //Unity callbacks
    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3,  1);
        timeText.text = time.ToString();
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
            else if(!gameOver)
            {
                Pause();
            }
        }

        //Restart
        if(Input.GetKeyDown(KeyCode.F))
        {
            Restart();
        }
        //Quit
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    //Time management
    private void Resume()
    {
        Time.timeScale = 1;
        Paused = false;
        pausePanel.SetActive(false);
    }
    private void Pause()
    {
        Time.timeScale = 0;
        Paused = true;
        pausePanel.SetActive(true);
    }

    void Stopper()
    {
        time--;
        timeText.text = time.ToString();
        freezeImage.gameObject.SetActive(false);
        if(time <= 0)
        {
            //GameOver
            CancelInvoke(nameof(Stopper));
            losePanel.SetActive(true);
            Time.timeScale = 0;
            gameOver = true;
        }
    }

    //Pickups
    public void PickDiamond()
    {
        diamonds++;
        diamondsText.text = diamonds.ToString();
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
        freezeImage.gameObject.SetActive(true);
    }
    public void PickKey(KeyColor color)
    {
        switch (color)
        {
            case KeyColor.Gold:
                goldKeys++;
                goldKeysText.text = goldKeys.ToString();
                break;
            case KeyColor.Red:
                redKeys++;
                redKeysText.text = redKeys.ToString();
                break;
            case KeyColor.Green:
                greenKeys++;
                greenKeysText.text = greenKeys.ToString();
                break;
        }
    }

    //Interactions
    public bool CheckKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Gold:
                if(goldKeys > 0)
                {
                    goldKeys--;
                    goldKeysText.text = goldKeys.ToString();
                    return true;
                }
                break;
            case KeyColor.Red:
                if (redKeys > 0)
                {
                    redKeys--;
                    redKeysText.text = redKeys.ToString();
                    return true;
                }
                break;
            case KeyColor.Green:
                if (greenKeys > 0)
                {
                    greenKeys--;
                    greenKeysText.text = greenKeys.ToString();
                    return true;
                }
                break;
        }

        return false;
    }

    public void Win()
    {
        winPanel.SetActive(true);
        gameOver = true;
        Time.timeScale = 0;
    }
    private void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
