using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public audioManager am;
    public AudioSource SFX;
    public AudioSource Music;

    float sfxVolume;
    public Slider sfxVolumeSlider;
    float musicVolume;
    public Slider musicVolumeSlider;

    private void Awake()
    {
        //sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
        //musicVolume = PlayerPrefs.GetFloat("MusicVolume");

        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        //SFX.volume = PlayerPrefs.GetFloat("SFXVolume");
        //Music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
    private void Start()
    {
       
    }

    private void Update()
    {

        sfxVolume = sfxVolumeSlider.value;
        musicVolume = musicVolumeSlider.value;

        SFX.volume = sfxVolume;
        Music.volume = musicVolume;

        PlayerPrefs.SetFloat("MusicVolume", Music.volume);
        PlayerPrefs.SetFloat("SFXVolume", SFX.volume);

    }
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("cerrando juego");
    }

    
}
