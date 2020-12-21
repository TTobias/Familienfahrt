using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public KeyCode button;
    State state = State.Inactive;

    public GameObject pauseMenu;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(button))
        {
            switch (state)
            {
                case State.Active:
                    pauseMenu.SetActive(false);
                    state = State.Inactive;
                    Time.timeScale = 1f;
                    Cursor.lockState = CursorLockMode.Locked;
                    break;
                case State.Inactive:
                    pauseMenu.SetActive(true);
                    state = State.Active;
                    Time.timeScale = 0f;
                    Cursor.lockState = CursorLockMode.None;
                    break;
                default:
                    break;
            }
        }
    }

    public void SetMasterVolume (float level)
    {
        mixer.SetFloat("Master Volume", level);
    }
    public void SetAmbienceVolume(float level)
    {
        mixer.SetFloat("Ambience Volume", level);
    }
    public void SetEffectsVolume(float level)
    {
        mixer.SetFloat("Effects Volume", level);
    }
    public void SetRadioVolume(float level)
    {
        mixer.SetFloat("Radio Volume", level);
    }

    enum State
    {
        Active, Inactive
    }
}
