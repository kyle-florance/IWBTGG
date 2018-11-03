using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public AudioMixer masterMixer;

    public GameObject pauseMenu;

    public static bool isPaused = false;

    void Update()
    {
        if (Input.GetButtonDown("Pause") && SceneManager.GetActiveScene().name != "Main Menu")
        {
            if(!isPaused)
            {
                pauseGame();
            }
            else
            {
                unpauseGame();
            }
        }
    }

    public void SetMusicVolume(float volume)
    {
        masterMixer.SetFloat("musicVolume", volume);
    }

    public void SetEffectVolume(float volume)
    {
        masterMixer.SetFloat("effectsVolume", volume);
    }

    public void SetMasterVolume(float volume)
    {
        masterMixer.SetFloat("masterVolume", volume);
    }

    public void FullScreenToggle(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    public void unpauseGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void backButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
