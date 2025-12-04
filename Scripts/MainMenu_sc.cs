using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_sc : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sfxSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Sahne");
    } 

    public void OnVolumeChanged()
    {
        MusicManager_sc.instance.SetVolume(volumeSlider.value);
    }

    public void OnSFXVolumeChanged()
    {
        SFXManager_sc.instance.SetSFXVolume(sfxSlider.value);
    }
}
