using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogError("Multiple GMs in the scene:" + gameObject.name);
        }
    }
    #endregion

    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public AudioClip diamondPick;
    public void PlayDiamondPick()
    {
        audioSource.PlayOneShot(diamondPick);
    }

    public AudioClip keyPick;
    public void PlayKeyPick()
    {
        audioSource.PlayOneShot(keyPick);
    }

    public AudioClip freezePick;
    public void PlayFreezePick()
    {
        audioSource.PlayOneShot(freezePick);
    }
    public AudioClip clock;
    public void PlayClock()
    {
        audioSource.PlayOneShot(clock);
    }
    public AudioClip lose, win, pause, interaction;

    public void PlayLoseClip()
    {
        audioSource.PlayOneShot(lose);
    }
    public void PlayWin()
    {
        audioSource.PlayOneShot(win);
    }
    public void PlayPause()
    {
        audioSource.PlayOneShot(pause);
    }
    public void PlayInteraction()
    {
        audioSource.PlayOneShot(interaction);
    }
}
