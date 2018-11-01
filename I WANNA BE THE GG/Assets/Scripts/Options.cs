using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour {

    public AudioMixer masterMixer;
    public LensFlare flare;
    public GameObject optionMenu;

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

    public void backButton()
    {
        flare.enabled = true;
        optionMenu.SetActive(false);
    }
}
